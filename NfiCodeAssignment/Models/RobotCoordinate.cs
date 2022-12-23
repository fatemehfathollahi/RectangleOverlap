using System.Collections.Generic;

namespace NfiCodeAssignment.Models
{
    public class RobotCoordinate
    {
        /// <summary>
        /// robot ID
        /// </summary>
        public string RobotId { get; set; }
        /// <summary>
        /// Origin coordinate of robot
        /// </summary>
        public Point Point { get; set; }
        /// <summary>
        /// The list of assigned position in each time step
        /// </summary>
        public List<RobotTimeStep> TimeSteps { get; set; }
    }
}
