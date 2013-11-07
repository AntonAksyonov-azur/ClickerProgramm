using System.Collections.Generic;
using System.Drawing;

namespace Clicker.com.arazect.clicker.data
{
    public class ProgrammConfig : IConfigurationObject
    {
        public List<ClickPoint> ClickPoints;
        public Point WindowPoint;
        public Point NudControlsLimit;
        public int TimerInterval;
        public int RepeatCount;

        public void InitDefault()
        {
            ClickPoints = new List<ClickPoint>();
            
            WindowPoint = Point.Empty;
            NudControlsLimit = new Point(9999, 9999);

            TimerInterval = 100;
            RepeatCount = 1;
        }
    }
}