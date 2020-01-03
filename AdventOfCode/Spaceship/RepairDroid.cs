using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Pontemonti.AdventOfCode.Geometry;
using Pontemonti.AdventOfCode.Graph;
using Pontemonti.AdventOfCode.Intcode;
using Pontemonti.AdventOfCode.Utilities;

namespace Pontemonti.AdventOfCode.Spaceship
{
    public class RepairDroid
    {
        private const string programString = "3,1033,1008,1033,1,1032,1005,1032,31,1008,1033,2,1032,1005,1032,58,1008,1033,3,1032,1005,1032,81,1008,1033,4,1032,1005,1032,104,99,101,0,1034,1039,1002,1036,1,1041,1001,1035,-1,1040,1008,1038,0,1043,102,-1,1043,1032,1,1037,1032,1042,1105,1,124,1001,1034,0,1039,101,0,1036,1041,1001,1035,1,1040,1008,1038,0,1043,1,1037,1038,1042,1105,1,124,1001,1034,-1,1039,1008,1036,0,1041,102,1,1035,1040,1001,1038,0,1043,101,0,1037,1042,1106,0,124,1001,1034,1,1039,1008,1036,0,1041,101,0,1035,1040,1002,1038,1,1043,101,0,1037,1042,1006,1039,217,1006,1040,217,1008,1039,40,1032,1005,1032,217,1008,1040,40,1032,1005,1032,217,1008,1039,33,1032,1006,1032,165,1008,1040,35,1032,1006,1032,165,1101,0,2,1044,1105,1,224,2,1041,1043,1032,1006,1032,179,1101,0,1,1044,1106,0,224,1,1041,1043,1032,1006,1032,217,1,1042,1043,1032,1001,1032,-1,1032,1002,1032,39,1032,1,1032,1039,1032,101,-1,1032,1032,101,252,1032,211,1007,0,68,1044,1105,1,224,1101,0,0,1044,1106,0,224,1006,1044,247,101,0,1039,1034,102,1,1040,1035,1001,1041,0,1036,102,1,1043,1038,101,0,1042,1037,4,1044,1105,1,0,30,84,39,21,27,93,20,65,45,95,19,6,71,25,33,13,80,53,60,70,65,80,45,65,53,62,93,13,19,72,33,49,54,92,9,29,25,69,7,46,9,96,97,70,8,69,71,97,3,75,94,49,96,11,76,24,29,84,87,99,33,76,83,83,21,62,97,82,63,71,78,74,29,94,90,34,92,58,75,44,66,99,28,37,84,18,18,94,86,50,4,74,3,96,74,39,99,55,93,44,94,55,40,78,2,88,70,6,69,67,87,40,4,93,76,30,1,42,40,87,23,83,89,24,73,19,62,88,43,92,94,50,71,53,19,75,22,9,82,46,65,84,92,63,99,57,23,62,93,61,14,87,67,84,90,38,96,83,33,63,40,80,75,10,79,89,52,14,97,32,87,72,57,79,7,79,6,93,66,77,50,19,97,78,65,96,24,94,80,12,10,70,9,60,77,67,17,83,76,36,79,27,43,91,6,72,77,49,4,47,56,85,81,11,46,96,93,33,82,44,69,49,34,98,77,95,38,19,85,1,62,73,49,95,39,62,36,83,23,93,34,32,21,94,89,30,85,76,13,92,87,3,84,43,3,74,39,81,6,85,16,69,89,21,56,80,65,92,84,97,7,63,23,8,87,37,70,54,75,92,95,96,51,83,34,24,86,39,59,48,89,45,34,89,72,3,77,63,98,38,70,39,38,98,97,85,46,96,53,81,89,27,83,75,31,81,71,39,81,62,79,11,78,18,90,94,1,91,1,79,77,74,64,20,73,55,75,78,2,77,24,92,56,55,25,70,21,38,69,49,81,19,34,92,97,74,61,79,18,77,51,76,62,92,10,85,83,87,39,90,31,98,95,61,32,63,82,59,75,65,53,72,91,17,75,75,54,85,57,32,13,39,70,48,86,59,50,96,32,23,84,61,85,48,59,92,33,15,58,83,95,48,80,70,84,58,69,70,37,99,18,73,79,32,71,22,41,75,26,71,25,55,73,31,5,53,71,95,65,87,50,62,95,80,54,95,73,79,20,94,65,83,33,26,88,3,11,99,76,93,28,97,67,49,90,94,19,85,28,10,96,70,55,84,17,75,33,47,91,44,88,96,1,6,89,40,69,27,58,98,61,25,77,79,43,83,38,13,72,44,99,20,33,69,8,5,47,72,78,24,53,94,78,39,99,87,9,63,82,52,69,64,48,93,46,48,89,22,84,32,69,7,36,99,80,4,27,92,54,14,85,56,19,99,93,99,49,67,82,90,23,10,77,77,37,79,67,78,27,81,79,34,67,81,40,88,76,89,94,64,80,73,79,57,72,22,14,93,3,88,84,88,41,12,29,4,97,57,83,38,93,51,55,20,75,57,78,22,76,22,24,85,91,79,27,19,46,90,18,71,3,39,28,26,94,87,83,31,35,73,56,99,83,35,65,92,45,98,93,2,73,88,15,90,62,85,95,20,96,75,52,4,62,81,78,49,67,69,20,5,85,72,79,45,34,73,89,20,37,60,79,97,6,41,78,40,70,42,29,89,21,76,88,44,82,17,9,73,52,71,73,25,89,71,30,82,85,26,86,61,43,7,71,13,99,72,40,95,79,39,67,39,65,90,91,14,96,20,73,98,66,13,92,70,1,93,2,86,45,54,85,73,30,62,14,97,89,39,77,99,40,89,76,49,97,42,60,97,62,82,35,98,49,80,15,91,34,87,65,77,44,93,65,87,76,82,20,78,46,90,18,81,73,98,47,99,48,69,2,82,90,90,47,85,49,94,37,81,76,90,0,0,21,21,1,10,1,0,0,0,0,0,0";

        private IntcodeComputer intcodeComputer;
        private Point currentPosition;
        private Point oxygenSystemPosition;
        private RepairDroidMovementCommand currentMovementCommand;
        private HashSet<Point> validPositions;
        internal HashSet<Point> wallPositions;
        private Stack<RepairDroidNavigationStep> potentialPointStack;
        private HashSet<Point> positionsVisited;
        private RepairDroidMovementCommand[] movementCommands = new[]
        {
            RepairDroidMovementCommand.North,
            RepairDroidMovementCommand.East,
            RepairDroidMovementCommand.South,
            RepairDroidMovementCommand.West
        };
        private Queue<RepairDroidMovementCommand> movementCommandQueue;
        private Stack<RepairDroidNavigationStep> currentShortestPath;
        private Dictionary<Point, RepairDroidNavigationStep?> knownPositions;

        private RepairDroid(IntcodeComputer intcodeComputer)
        {
            this.intcodeComputer = intcodeComputer;
            this.intcodeComputer.OutputSent += this.IntcodeComputerOutputSent;
            this.intcodeComputer.WaitingForInput += this.IntcodeComputerWaitingForInput;
        }

        public static RepairDroid Create()
        {
            long[] program = InputHelper.ReadInt64CommaList(programString).ToArray();
            IntcodeComputer intcodeComputer = new IntcodeComputer("Repair Droid", program);
            RepairDroid repairDroid = new RepairDroid(intcodeComputer);
            return repairDroid;
        }

        public void DrawMap()
        {
            Stack<RepairDroidNavigationStep> currentShortestPathToOxygenSystem = this.GetShortestPathToOxygenSystem();

            int minX = this.wallPositions.Min(p => p.X);
            int maxX = this.wallPositions.Max(p => p.X);
            int widthX = maxX - minX;
            int minY = this.wallPositions.Min(p => p.Y);
            int maxY = this.wallPositions.Max(p => p.Y);
            int heightY = maxY - minY;
            for (int y = maxY; y >= minY; y--)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    Point p = new Point(x, y);
                    if (this.wallPositions.Contains(p))
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    string s = " ";
                    if (p.X == 0 && p.Y == 0)
                    {
                        s = "o";
                    }
                    else if (p.Equals(this.oxygenSystemPosition))
                    {
                        s = "X";
                    }
                    else if (currentShortestPathToOxygenSystem.Any(step => step.DestinationPosition.Equals(p) || step.OriginPosition.Equals(p)))
                    {
                        s = ".";
                    }

                    Console.Write(s);
                }

                Console.WriteLine();
            }
        }

        public List<RepairDroidNavigationStep> FindShortestPathToOxygenSystem()
        {
            this.currentPosition = new Point(0, 0);
            this.currentShortestPath = new Stack<RepairDroidNavigationStep>();
            this.validPositions = new HashSet<Point>();
            this.wallPositions = new HashSet<Point>();
            this.positionsVisited = new HashSet<Point>();
            this.positionsVisited.Add(this.currentPosition);
            this.potentialPointStack = new Stack<RepairDroidNavigationStep>();
            this.movementCommandQueue = new Queue<RepairDroidMovementCommand>();
            this.knownPositions = new Dictionary<Point, RepairDroidNavigationStep?>();
            this.knownPositions.Add(this.currentPosition, null);
            this.EnqueuePotentialMoves();

            // this executes in a loop forever - we might want to find a way to terminate it
            this.intcodeComputer.Run();

            // remove duplicate paths between duplicate positions (that means we back-tracked)
            // assume there are walls between empty spaces (i.e. there are only "tunnels", 
            // no "rooms") so this is the only thing we need to do to find the shortest path.
            Stack<RepairDroidNavigationStep> currentShortestPathToOxygenSystem = this.GetShortestPathToOxygenSystem();
            return currentShortestPathToOxygenSystem.ToList();
        }

        public int GetMinutesToFillEntireAreaWithOxygen()
        {
            List<RepairDroidNavigationStep> navigationStepsToOxygenSystem = this.FindShortestPathToOxygenSystem();
            List<Vertex<Point>> vertices = new List<Vertex<Point>>();
            List<Edge<Point>> edges = new List<Edge<Point>>();
            foreach (Point validPosition in this.knownPositions.Keys)
            {
                Vertex<Point> vertex = new Vertex<Point>(validPosition);
                vertices.Add(vertex);
            }

            foreach (Vertex<Point> vertex in vertices)
            {
                foreach (RepairDroidMovementCommand movementCommand in this.movementCommands)
                {
                    Point adjacentPoint = vertex.Value.GetNextPosition(movementCommand);
                    Vertex<Point> adjacentVertex = vertices.FirstOrDefault(v => v.Value.Equals(adjacentPoint));
                    if (adjacentVertex != null)
                    {
                        Edge<Point> edge = new Edge<Point>(vertex, adjacentVertex);
                        edges.Add(edge);
                    }
                }
            }

            Graph<Point> graph = new Graph<Point>(vertices, edges);

            Vertex<Point> oxygenSystemVertex = new Vertex<Point>(this.oxygenSystemPosition);
            List<Edge<Point>> edgesToFarthestVertex = graph.FindPathToFarthestVertex(oxygenSystemVertex).ToList();
            return edgesToFarthestVertex.Count;
        }

        private void EnqueuePotentialMoves()
        {
            List<RepairDroidMovementCommand> potentialMovementCommands = new List<RepairDroidMovementCommand>(this.movementCommands);
            foreach (RepairDroidMovementCommand potentialMovementCommand in potentialMovementCommands)
            {
                Point potentialNextPosition = this.currentPosition.GetNextPosition(potentialMovementCommand);
                if (this.IsPositionGoodToVisit(potentialNextPosition))
                {
                    Stack<RepairDroidNavigationStep> copyOfCurrentShortestPath = new Stack<RepairDroidNavigationStep>(this.currentShortestPath.ToArray().Reverse());
                    RepairDroidNavigationStep navigationStep = new RepairDroidNavigationStep(this.currentPosition, potentialMovementCommand, copyOfCurrentShortestPath);
                    this.potentialPointStack.Push(navigationStep);
                }
            }
        }

        private Stack<RepairDroidNavigationStep> GetShortestPathToOxygenSystem()
        {
            RepairDroidNavigationStep stepToOxygenSystem = this.knownPositions[this.oxygenSystemPosition];
            Stack<RepairDroidNavigationStep> currentShortestPathToOxygenSystem = new Stack<RepairDroidNavigationStep>(stepToOxygenSystem.ShortestPathToOrigin.ToArray().Reverse());
            currentShortestPathToOxygenSystem.Push(stepToOxygenSystem);
            return currentShortestPathToOxygenSystem;
        }

        private bool IsPositionGoodToVisit(Point potentialPosition)
        {
            if (this.positionsVisited.Contains(potentialPosition))
            {
                // We've already been here - no use in going back
                return false;
            }

            if (this.wallPositions.Contains(potentialPosition))
            {
                // We already know that this is a wall
                return false;
            }

            if (this.potentialPointStack.Any(step => step.DestinationPosition.Equals(potentialPosition)))
            {
                // We're already planning to go here
                return false;
            }

            return true;
        }

        private void IntcodeComputerOutputSent(object? sender, long e)
        {
            RepairDroidStatusCode statusCode = (RepairDroidStatusCode)e;
            switch (statusCode)
            {
                case RepairDroidStatusCode.BlockedByWall:
                    this.UpdateWallFound();
                    break;
                case RepairDroidStatusCode.MovedOneStep:
                    this.UpdateCurrentPosition();
                    break;
                case RepairDroidStatusCode.OxygenSystemFound:
                    this.UpdateCurrentPosition();
                    this.oxygenSystemPosition = this.currentPosition;
                    break;
            }
        }

        private void IntcodeComputerWaitingForInput(object? sender, EventArgs e)
        {
            if (!this.HasNextMovementCommand())
            {
                // The remote control program executes in a loop forever
                // Since we found the oxygen system, signal to the computer to stop
                this.intcodeComputer.TerminateExecution();

                this.DrawMap();
                return;
            }

            RepairDroidMovementCommand movementCommand = this.FindNextMovementCommand();
            this.currentMovementCommand = movementCommand;
            Debug.WriteLine($"Move {movementCommand} from {this.currentPosition} to {this.currentPosition.GetNextPosition(movementCommand)}");
            this.intcodeComputer.ProvideInput((long)movementCommand);
        }

        private bool HasNextMovementCommand() => this.movementCommandQueue.Any() || this.potentialPointStack.Any();

        private RepairDroidMovementCommand FindNextMovementCommand()
        {
            if (!this.movementCommandQueue.Any())
            {
                // No command queued up. What's the next navigation step?
                RepairDroidNavigationStep nextStep = this.potentialPointStack.Pop();
                if (!nextStep.OriginPosition.Equals(this.currentPosition))
                {
                    RepairDroidMovementCommand[] movementCommandsToOrigin = this.FindMovementCommandsToPosition(nextStep.OriginPosition).ToArray();
                    foreach (RepairDroidMovementCommand movementCommandToOrigin in movementCommandsToOrigin)
                    {
                        this.movementCommandQueue.Enqueue(movementCommandToOrigin);
                    }
                }

                this.movementCommandQueue.Enqueue(nextStep.MovementCommand);
            }

            // At this point the queue should contain something. Return the first item.
            return this.movementCommandQueue.Dequeue();
        }

        private IEnumerable<RepairDroidMovementCommand> FindMovementCommandsToPosition(Point originPosition)
        {
            // Figure out where we're going
            RepairDroidNavigationStep navigationStepToOrigin = this.knownPositions[originPosition];

            // This isn't intuitive, but the known positions contains the navigation step to get to the position where we want to go
            // the navigation step's "shortest path to origin" is the path to the origin, i.e. before the navigation step
            // meaning we need to add the navigation step to its own shortest path
            Stack<RepairDroidNavigationStep> shortestPathToOrigin;
            if (navigationStepToOrigin == null)
            {
                shortestPathToOrigin = new Stack<RepairDroidNavigationStep>();
            }
            else
            {
                shortestPathToOrigin = new Stack<RepairDroidNavigationStep>(navigationStepToOrigin.ShortestPathToOrigin.ToArray().Reverse());
                shortestPathToOrigin.Push(navigationStepToOrigin);
            }

            // Copy the current path so that we can pop items to start backtracking
            Stack<RepairDroidNavigationStep> copyOfCurrentShortestPath = new Stack<RepairDroidNavigationStep>(this.currentShortestPath.ToArray().Reverse());
            bool shouldNavigateForward = !copyOfCurrentShortestPath.Any();
            RepairDroidNavigationStep previousStep = null;
            while (copyOfCurrentShortestPath.Any())
            {
                // Step one step back at a time
                // For each step, see if we have found the position we're looking for
                // ... or if we've come to a point that's part of the path to where we're going
                previousStep = copyOfCurrentShortestPath.Pop();

                // We're going backwards, so reverse the movement command
                RepairDroidMovementCommand reverseMovementCommand = previousStep.MovementCommand.Reverse();
                yield return reverseMovementCommand;

                if (previousStep.OriginPosition.Equals(originPosition))
                {
                    // Position found - nothing left to do
                    break;
                }
                else if (shortestPathToOrigin.Any(step => step.OriginPosition.Equals(previousStep.OriginPosition)))
                {
                    // This position exists
                    shouldNavigateForward = true;
                    break;
                }
            }

            if (shouldNavigateForward)
            {
                // Figure out which forward steps are needed
                Stack<RepairDroidNavigationStep> copyOfShortestPathToOrigin = new Stack<RepairDroidNavigationStep>(shortestPathToOrigin.ToArray().Reverse());
                Stack<RepairDroidNavigationStep> forwardSteps = new Stack<RepairDroidNavigationStep>();
                while (copyOfShortestPathToOrigin.Any())
                {
                    RepairDroidNavigationStep previousStepToOrigin = copyOfShortestPathToOrigin.Pop();
                    forwardSteps.Push(previousStepToOrigin);
                    if (previousStep != null && previousStep.OriginPosition.Equals(previousStepToOrigin.OriginPosition))
                    {
                        // We found the position - we have all the steps we need
                        break;
                    }
                }

                // Now navigate forward
                while (forwardSteps.Any())
                {
                    RepairDroidNavigationStep forwardStep = forwardSteps.Pop();
                    yield return forwardStep.MovementCommand;
                }
            }
        }

        private void UpdateCurrentPosition()
        {
            Stack<RepairDroidNavigationStep> copyOfCurrentShortestPath = new Stack<RepairDroidNavigationStep>(this.currentShortestPath.ToArray().Reverse());
            RepairDroidNavigationStep navigationStep = new RepairDroidNavigationStep(this.currentPosition, this.currentMovementCommand, copyOfCurrentShortestPath);

            Point newPosition = this.currentPosition.GetNextPosition(this.currentMovementCommand);
            bool isNewPosition = !this.knownPositions.ContainsKey(newPosition);
            Debug.WriteLine($"Moved from {this.currentPosition} to {newPosition} (is new: {isNewPosition})");
            if (isNewPosition)
            {
                this.knownPositions.Add(newPosition, navigationStep);
            }

            this.currentPosition = newPosition;
            this.positionsVisited.Add(this.currentPosition);

            this.validPositions.Add(this.currentPosition);

            // Update shortest path
            if (this.currentShortestPath.Any() && this.currentShortestPath.Peek().OriginPosition.Equals(this.currentPosition))
            {
                // We went back one step - pop it
                this.currentShortestPath.Pop();
            }
            else
            {
                this.currentShortestPath.Push(navigationStep);
            }

            if (isNewPosition)
            {
                this.EnqueuePotentialMoves();
            }
        }

        private void UpdateWallFound()
        {
            Point wallPosition = this.currentPosition.GetNextPosition(this.currentMovementCommand);
            Debug.WriteLine($"Wall found at {wallPosition}");
            this.wallPositions.Add(wallPosition);
        }
    }
}
