using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgeCars
{
    class Car
    {
        public Point Position { get; set; }
        public bool IsIncoming { get; set; }

        private int counter = 0;
        public Car()
        {

        }

        public Car(Point position, bool isIncoming)
        {
            this.Position = position;
            this.IsIncoming = isIncoming;
        }

        public void Draw(Graphics g)
        {
            if (IsIncoming)
                g.FillRectangle(Brushes.Black, this.Position.X * 200 + 150, this.Position.Y * 50, 50, 50);
            else
                g.FillRectangle(Brushes.Red, this.Position.X * 200 + 150, this.Position.Y * 50, 50, 50);
        }

        public void MoveBottom()
        {
            if (this.counter == 2)
            {
                this.Position = new Point(this.Position.X, this.Position.Y + 1);
                counter = 0;
            }
            else
                counter++;
        }

        public void MoveLeft() => this.Position = new Point(this.Position.X - 1, this.Position.Y);

        public void MoveRight() => this.Position = new Point(this.Position.X + 1, this.Position.Y);
    }
}
