using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MarkerPositions
{
    public class MarkerMediator
    {
        private readonly List<Marker> _markers = new List<Marker>();

        public Marker CreateMarker()
        {
            var marker = new Marker();
            marker.SetMediator(this);
            return marker;
        }

        public void Send(Point location, Marker marker)
        {
            _markers.Where(m => m != marker).ToList().ForEach(m => m.ReceiveLocation(location));
        }
    }
}
