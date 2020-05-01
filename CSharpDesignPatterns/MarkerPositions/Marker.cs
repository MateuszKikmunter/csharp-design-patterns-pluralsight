using System;
using System.Drawing;
using System.Windows.Forms;

namespace MarkerPositions
{
    public class Marker : Label
    {
        private MarkerMediator _mediator;

        private Point _mouseDownLocation;

        public Marker()
        {
            Text = "{Drag me}";
            TextAlign = ContentAlignment.MiddleCenter;
            MouseDown += OnMouseDown;
            MouseMove += OnMouseMove;
        }

        public void SetMediator(MarkerMediator mediator)
        {
            _mediator = mediator;
        }

        public void ReceiveLocation(Point location)
        {
            var distance = CalcDistance(location);
            if (distance < 100 && BackColor != Color.Red)
            {
                BackColor = Color.Red;
            }
            else if (distance >= 100 && BackColor != Color.Green)
            {
                BackColor = Color.Green;
            }

            double CalcDistance(Point point) => Math.Sqrt(Math.Pow(point.X - Location.X, 2) + Math.Pow(point.Y - Location.Y, 2));
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mouseDownLocation = e.Location;
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Text = Location.ToString();
                Left = e.X + Left - _mouseDownLocation.X;
                Top = e.Y + Top - _mouseDownLocation.Y;
                _mediator.Send(Location, this);
            }
        }
    }
}
