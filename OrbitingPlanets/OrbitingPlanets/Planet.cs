using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitingPlanets
{
    public class Planet
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Planet(int x, int y)
        {
            X = (float)x;
            Y = (float)y;
        }

        // Called every 30 ms (30 ms = .03 seconds) to update the position center of gravity
        public void UpdatePosition(int center_x, int center_y) 
        {
            // Use trigonometrey to find position
            float s = (float)Math.Sin(.08);
            float c = (float)Math.Cos(.08);

            // Set X and Y position
            X -= (float)center_x;
            Y -= (float)center_y;

            // Get new X and Y
            float xnew = X * c - Y * s;
            float ynew = X * s + Y * c;

            // Set new X and Y position and update
            X = xnew + (float)center_x;
            Y = ynew + (float)center_y;
        }
    }
}
