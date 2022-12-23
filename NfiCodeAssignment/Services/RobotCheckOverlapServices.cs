using NfiCodeAssignment.Models;
using System.Collections.Generic;

namespace NfiCodeAssignment.Services
{
    public class RobotCheckOverlapServices
    {
        private readonly List<Robot> CoordinateRobots;
        public RobotCheckOverlapServices(List<Robot> coordinateRobots)
        {
            CoordinateRobots = coordinateRobots;
        }

        /// <summary>
        /// Validates whether there are collisions between any of the robots.
        /// </summary>
        /// <param name="robot">The Robot Model</param>
        /// <returns>Whether the robots overlap. return true if there are collisions between any of the robots.</returns>
        public bool IsOverLapping(Robot robot)
        {
            for (int i = 0; i < CoordinateRobots.Count; i++)
            {
                var otherRobot = CoordinateRobots[i];
                /// <summary>
                ///The formula to determine whether two rectangles overlap
                /// </summary>
                if (robot.Top <= otherRobot.Bottom
                    && robot.Bottom >= otherRobot.Top
                    && robot.Left >= otherRobot.Right
                    && robot.Right <= otherRobot.Left)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
