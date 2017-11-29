using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitingPlanets
{
    public class Center
    {
        public int X { get; set; }
        public int Y { get; set; }

        public List<Planet> Planets { get; set; } // List for all the planets on screen
        public double Radius { get; set; }

        public int RadiusUpperLeftX
        {
            get
            {
                return (X - (int)Radius);
            }
        }

        public int RadiusUpperLeftY
        {
            get
            {
                return (Y - (int)Radius);
            }
        }

        public Center(int x, int y, int radius)
        {
            X = x;
            Y = y;
            Radius = (double)radius;
            Planets = new List<Planet>();
        }

        public void UpdatePlanetsPosition()
        {
            foreach (Planet planet in Planets)
            {
                planet.UpdatePosition(X, Y);
            }
        }

        public bool IsInsideCenter(int x, int y) // Check if coordinates are within Center's radius
        {
            int diffX = X - x;
            int diffY = Y - y;
            double distance = Math.Sqrt(Math.Pow(diffX, 2) + Math.Pow(diffY, 2)); // Distance = sqrt(diffx^2 + diffy^2)
            return (distance <= Radius); // true if distance is < or = radius value
        }

        public void AddPlanets(int x, int y)
        {
            Planets.Add(new Planet(x, y));
        }
    } 
}
