using System;

namespace Pontemonti.AdventOfCode.Geometry
{
    public class Moon
    {
        public Moon(int x, int y, int z, int velocityX, int velocityY, int velocityZ)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.VelocityX = velocityX;
            this.VelocityY = velocityY;
            this.VelocityZ = velocityZ;
        }

        public Moon(int x, int y, int z)
            : this(x, y, z, 0, 0, 0)
        {
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int VelocityX { get; set; }
        public int VelocityY { get; set; }
        public int VelocityZ { get; set; }
        public int PotentialEnergy
            => Math.Abs(this.X) + Math.Abs(this.Y) + Math.Abs(this.Z);
        public int KineticEnergy
            => Math.Abs(this.VelocityX) + Math.Abs(this.VelocityY) + Math.Abs(this.VelocityZ);
        public int TotalEnergy => this.PotentialEnergy * this.KineticEnergy;

        public Moon Clone()
            => new Moon(this.X, this.Y, this.Z, this.VelocityX, this.VelocityY, this.VelocityZ);

        public override string ToString()
            => $"pos=<x={this.X}, y={this.Y}, z={this.Z}>, vel=<x={this.VelocityX}, y={this.VelocityY}, z={this.VelocityZ}>";
    }
}