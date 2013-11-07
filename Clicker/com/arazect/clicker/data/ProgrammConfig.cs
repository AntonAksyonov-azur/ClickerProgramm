using System.Collections.Generic;
using System.Drawing;
using Clicker.com.arazect.data;

namespace Clicker.com.arazect.clicker.data
{
    public class ProgrammConfig : IConfigurationObject
    {
        public List<ClickPoint> ClickPoints;
        public Point WindowPoint;
        public Point NudControlsLimit;

        public void InitDefault()
        {
            ClickPoints = new List<ClickPoint>();

            WindowPoint = Point.Empty;

            NudControlsLimit = new Point(9999, 9999);
        }
    }
}