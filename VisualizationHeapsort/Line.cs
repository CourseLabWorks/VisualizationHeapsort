using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VisualizationHeapsort
{
    class Line
    {
        int position;
        Point vertex;
        int angle = 0;
        public int Position
        {
            get { return position; }
        }
        public Point Vertex
        {
            get { return vertex; }
        }
        public int Angle
        {
            get { return angle; }
            set
            {
                if (value > 180)
                    angle = 180;
                if (value < 0)
                    angle = 0;
                angle = value;
                vertex = new Point(-(int)(50 * Math.Cos(angle * Math.PI / 180)) + position, -(int)(50 * Math.Sin(angle * Math.PI / 180)) + 55);
            }
        }

        public Line(int position, int angle)
        {
            this.position = position;
            Angle = angle;
            vertex = new Point(-(int)(50 * Math.Cos(angle * Math.PI / 180)) + position, -(int)(50 * Math.Sin(angle * Math.PI / 180)) + 55);
        }
    }
}