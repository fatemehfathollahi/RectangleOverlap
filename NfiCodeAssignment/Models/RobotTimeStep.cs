namespace NfiCodeAssignment.Models
{
    public class RobotTimeStep
    {
        /// <summary>
        /// The number of time steps
        /// </summary>
        public int TimeStep { get; set; }
        /// <summary>
        /// robot ID
        /// </summary>
        public string RobotId { get; set; }
        /// <summary>
        /// Visited position coordinate
        /// </summary>
        public Point Point { get; set; }
    }
}
