using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Geometry
{
    public class JupiterMoons
    {
        public JupiterMoons(IEnumerable<Moon> moons)
        {
            this.Moons = moons.ToArray();
        }

        public Moon[] Moons { get; }
        public int TotalEnergy => this.Moons.Sum(moon => moon.TotalEnergy);

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
    }
}
