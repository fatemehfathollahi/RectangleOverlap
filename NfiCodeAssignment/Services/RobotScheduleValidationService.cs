using NfiCodeAssignment.Models;
using NfiCodeAssignment.Utility;
using System.Collections.Generic;

namespace NfiCodeAssignment.Services
{
    public class RobotScheduleValidationService
    {

        /// <summary>
        /// Validates whether there are no collisions between any of the robots in the schedule.
        /// </summary>
        /// <param name="schedule">The schedule, as read from a file. See the "Readme.pdf" file in the root folder of
        /// this project for more information about the structure/contents of this string. </param>
        /// <returns>Whether the schedule is valid. The schedule is valid if there are no collisions between any of the
        /// robots.</returns>
        public bool ValidateSchedule(string schedule)
        {
            /// <summary>
            /// parse string file to a Schadule Model and use of The GetTimeStep method for get TimeStep value
            /// and The GetSchedule for return Schadule Model
            /// </summary>
            var parser = new Parser(schedule);
            /// <summary>
            /// Get The number of time steps
            /// </summary>
            var timeStep = parser.GetTimeStep();
            /// <summary>
            /// Get maked schedule model of file
            /// </summary>
            var robotSchedule = parser.GetSchedule();
            /// <summary>
            /// use service for Calculate RobotCoordinates
            /// </summary>
            var robotSetvices = new RobotServices(robotSchedule);
            /// <summary>
            /// for every time step calculate all coordinates of every robot and call the CheckRobotOverlap method
            /// </summary>
            for (int t = 0; t < timeStep; t++)
            {
                var robots = robotSetvices.CalculateRobotCoordinates(t);
                if (CheckRobotOverlap(robots)) return false;
            }
            return true;
        }

        /// <summary>
        /// Check ovelap robot on list of robot coordinates
        /// </summary>
        /// <param name="robots"></param> The list of robots that contains of top,left,right and bottom coordinates
        /// <returns>Whether the overlaping is Invalid.there are no overlap between any of the robots.</returns> 
        private bool CheckRobotOverlap(List<Robot> robots)
        {
            var _isOverlap = false;
            for (int i = 0; i < robots.Count; i++)
            {
                /// <summary>
                /// create an instance of the Robot class for comparison with other robots
                /// /// </summary>
                Robot robot = new Robot(
                    robots[i].Top,
                    robots[i].Left,
                    robots[i].Bottom,
                    robots[i].Right
                );
                /// <summary>
                /// we need this line becuase we dont have check overlap one robot with itself!
                /// </summary>
                robots.RemoveAt(i);
                /// <summary>
                ///call the IsOverLapping method  and check whether none of them doesn't have overlaps with the current robot instance
                /// </summary>
                var robotCheckOverlapServices = new RobotCheckOverlapServices(robots);
                _isOverlap = robotCheckOverlapServices.IsOverLapping(robot);
            }
            return _isOverlap;
        }
    }
}