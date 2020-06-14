using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DodgeCars
{
    public partial class Form1 : Form
    {
        Car car = new Car(new Point(0, 12), false);

        Keys pressed;

        bool isIncoming = false;

        int score = 1;

        int lineY = 50;

        List<Car> road = new List<Car>();
        public Form1()
        {
            InitializeComponent();

            road.Add(car);

            GameTimer.Start();
        }

        private void IncomingCar()
        {
            if(!isIncoming)
            {
                Car c = new Car(new Point(new Random().Next(0, 2), 0), true);

                road.Add(c);

                isIncoming = true;
            }
        }

        private void MoveCar()
        {
            switch(pressed)
            {
                case Keys.Left:
                    if(car.Position.X > 0)
                        car.MoveLeft();
                    break;

                case Keys.Right:
                    if(car.Position.X < 1)
                        car.MoveRight();
                    break;
            }

            IncomingCar();
            CheckCrash();
        }

        private void CheckCrash()
        {
            foreach(Car c in road)
            {
                if(c != null)
                {
                    if (car.Position == c.Position && c != car)
                    {
                        GameTimer.Stop();

                        MessageBox.Show("You crashed!");

                        this.Close();
                    }
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Car tempCar = new Car();

            //Asphalt
            g.FillRectangle(Brushes.DarkGray, 0, 0, 650, 850);

            //Lines
            for(int i = 0; i < 10; i++)
            {
                g.FillRectangle(Brushes.White, 275, -45, 20, 50);
                g.FillRectangle(Brushes.White, 275, 50, 20, 50);
                g.FillRectangle(Brushes.White, 275, 150, 20, 50);
                g.FillRectangle(Brushes.White, 275, 250, 20, 50);
                g.FillRectangle(Brushes.White, 275, 350, 20, 50);
                g.FillRectangle(Brushes.White, 275, 450, 20, 50);
                g.FillRectangle(Brushes.White, 275, 550, 20, 50);
                g.FillRectangle(Brushes.White, 275, 650, 20, 50);
                g.FillRectangle(Brushes.White, 275, 750, 20, 50);
            }

            foreach (Car c in road)
            {
                if(c != null)
                {
                    c.Draw(g);

                    if (c.IsIncoming)
                    {
                        c.MoveBottom();

                        if (c.Position.Y >= 15)
                        {
                            tempCar = c;

                            Score.Text = score++.ToString();

                            isIncoming = false;
                        }
                    }
                }
            }

            road.Remove(tempCar);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            MoveCar();

            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            pressed = e.KeyCode;
        }
    }
}
