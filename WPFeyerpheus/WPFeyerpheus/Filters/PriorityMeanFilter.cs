using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiraMiVoz.Filters
{
    public enum decreasingFunction
    {
        linear,
        quadratic
    };

    class PriorityMeanFilter : IFilter
    {
        private List<KeyValuePair<Point, int>> pointsWithPriority = new List<KeyValuePair<Point, int>>();
        private int numberOfPoints;
        private decreasingFunction function;
        private int weigths = 0;

        
        public PriorityMeanFilter(int numberOfPoints, decreasingFunction function)
        {
            this.numberOfPoints = numberOfPoints;
            this.function = function;

            for (int i = 0; i < numberOfPoints; i++)
            {
                pointsWithPriority.Add(new KeyValuePair<Point, int>(new Point(0, 0), numberOfPoints));

            }

            for (int i = 0; i < numberOfPoints; i++)
            {
                weigths += i;
            }

            Console.WriteLine(weigths);

        }

        public void push(Point point)
        {
            for (int i = 0; i < numberOfPoints - 1; i++)
            {
                pointsWithPriority[i+1] = new KeyValuePair<Point, int>(pointsWithPriority[i].Key, pointsWithPriority[i].Value - 1);
            }
        }

        public Point getMean()
        {
            Point weightedMean = new Point(0, 0);

            if (function == decreasingFunction.linear)
            {

                for (int i = 0; i < numberOfPoints; i++)
                {
                    weightedMean.X += pointsWithPriority[i].Key.X * pointsWithPriority[i].Value;
                    weightedMean.Y += pointsWithPriority[i].Key.Y * pointsWithPriority[i].Value;
                }

                weightedMean.X = weightedMean.X / weigths;
                weightedMean.Y = weightedMean.X / weigths;

            }

            return weightedMean;            

        }
    }
}
