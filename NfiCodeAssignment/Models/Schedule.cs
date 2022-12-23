using System.Collections.Generic;

namespace NfiCodeAssignment.Models
{
    public class Schedule
    {
        /// <summary>
        /// The store schedule and all coordinates of Robots after parse file 
        /// </summary>
        public List<RobotCoordinate> RobotCoordinates { get; set; }
    }
}
