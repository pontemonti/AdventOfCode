using Pontemonti.AdventOfCode.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Geometry
{
    public class JupiterMoons
    {
        private Moon[] initialMoonStates;

        public JupiterMoons(IEnumerable<Moon> moons)
        {
            this.initialMoonStates = moons.Select(moon => moon.Clone()).ToArray();
            this.Moons = moons.ToArray();
        }

        public Moon[] Moons { get; private set; }
        public int TotalEnergy => this.Moons.Sum(moon => moon.TotalEnergy);

        public long FindNumberOfStepsToRepeatState()
        {
            // Calculate by finding the number of steps to velocity zero for all moons
            // This is halfways (i.e. half a rotation), so multiply by two.
            this.ResetState();
            long numberOfStepsX = this.FindNumberOfStepsToVelocityZero(moon => moon.VelocityX);
            Console.WriteLine($"Number of X steps to velocity 0: {numberOfStepsX}");

            this.ResetState();
            long numberOfStepsY = this.FindNumberOfStepsToVelocityZero(moon => moon.VelocityY);
            Console.WriteLine($"Number of Y steps to velocity 0: {numberOfStepsY}");

            this.ResetState();
            long numberOfStepsZ = this.FindNumberOfStepsToVelocityZero(moon => moon.VelocityZ);
            Console.WriteLine($"Number of Z steps to velocity 0: {numberOfStepsZ}");

            double numberOfStepsToHalf = MathHelper.LeastCommonMultiple(numberOfStepsX, MathHelper.LeastCommonMultiple(numberOfStepsY, numberOfStepsZ));
            return (long)numberOfStepsToHalf * 2;
        }

        public void ResetState()
        {
            this.Moons = this.initialMoonStates.Select(moon => moon.Clone()).ToArray();
        }

        public void RunOneStep()
        {
            this.ApplyGravity();
            this.ApplyVelocity();
        }

        public void RunSteps(int numberOfSteps)
        {
            for (int i = 0; i < numberOfSteps; i++)
            {
                this.RunOneStep();
            }
        }

        private void ApplyGravity()
        {
            for (int i = 0; i < this.Moons.Length; i++)
            {
                for (int j = i + 1; j < this.Moons.Length; j++)
                {
                    this.ApplyGravityForMoon(this.Moons[i], this.Moons[j]);
                }
            }
        }

        private void ApplyGravityForMoon(Moon moon1, Moon moon2)
        {
            this.ApplyGravityForMoonAxis(moon1.X, moon2.X, n => moon1.VelocityX += n, n => moon2.VelocityX += n);
            this.ApplyGravityForMoonAxis(moon1.Y, moon2.Y, n => moon1.VelocityY += n, n => moon2.VelocityY += n);
            this.ApplyGravityForMoonAxis(moon1.Z, moon2.Z, n => moon1.VelocityZ += n, n => moon2.VelocityZ += n);
        }

        private void ApplyGravityForMoonAxis(int moon1Position, int moon2Position, Action<int> moon1Update, Action<int> moon2Update)
        {
            if (moon1Position < moon2Position)
            {
                moon1Update(1);
                moon2Update(-1);
            }
            else if (moon1Position > moon2Position)
            {
                moon1Update(-1);
                moon2Update(1);
            }
        }

        private void ApplyVelocity()
        {
            foreach (Moon moon in this.Moons)
            {
                moon.X += moon.VelocityX;
                moon.Y += moon.VelocityY;
                moon.Z += moon.VelocityZ;
            }
        }

        private long FindNumberOfStepsToVelocityZero(Func<Moon, int> getVelocityFunction)
        {
            long numberOfSteps = 0;
            bool isVelocityZeroFound = false;
            while (!isVelocityZeroFound)
            {
                this.RunOneStep();
                numberOfSteps++;
                isVelocityZeroFound = this.Moons.All(moon => getVelocityFunction(moon) == 0);
            }

            return numberOfSteps;
        }
    }
}
