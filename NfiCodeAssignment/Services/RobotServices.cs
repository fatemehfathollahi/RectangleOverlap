using NfiCodeAssignment.Models;
using System.Collections.Generic;
using System.Linq;

namespace NfiCodeAssignment.Services
{
    public class RobotServices
    {
        private readonly Schedule Schedule;
        public RobotServices(Schedule schedule)
        {
            Schedule = schedule;
        }

        /// <summary>
        /// Calculate other coordinates for every robot from the  origin point and visited point in every timestep 
        /// if we swap x,y of origin point and visited point we can calculate other point of robots
        /// </summary>
        /// <param name="timeStep">The timeStep</param>
        /// <returns>The list of Robot with their coordinates</returns>
        public List<Robot> CalculateRobotCoordinates(int timeStep)
        {
            var robots = new List<Robot>();
                Schedule.RobotCoordinates.ForEach(robot =>
                {
                    ///<summary>
                    ///For every time step, every robot will visit exactly 1 position. 
                    ///</summary>
                    var robotTimeStep = robot.TimeSteps.FirstOrDefault(step => step.TimeStep.Equals(timeStep));
                    /// <summary>
                    /// orign point
                    /// </summary>
                    var point1 = new Point { x = robot.Point.x, y = robot.Point.y };

                    /// <summary>
                    /// visited position point
                    /// </summary>
                    var point2 = new Point { x = robotTimeStep.Point.x, y = robotTimeStep.Point.y };
                    
                    /// <summary>
                    /// use origin.x and visitedPoint.y for find other point.
                    /// </summary>
                    var point3 = new Point { x = point1.x, y = point2.y };

                    /// <summary>
                    /// use visitedPoint.x and origin.y for find other point.
                    /// </summary>
                    var point4 = new Point { x = point2.x, y = point1.y };

                    /// <summary>
                    /// The list of 4 point of rectangle
                    /// </summary>
                    var points = new List<Point> { point1, point2, point3, point4 };

                    /// <summary>
                    /// find all of the coordinates but we need to know which is Top, Left, Right, or Bottom.
                    /// find maximum value of x and minimum value of y for BottomRight point.
                    /// find minimum value of x and maximum value of y for BottomRight point.
                    /// </summary>
                    var minX = points.Min(p => p.x);
                    var maxY = points.Max(p => p.y);
                    var maxX = points.Max(p => p.x);
                    var minY = points.Min(p => p.y);
                    /// <summary>
                    /// TopLeft coordinates
                    /// </summary>
                    var topLeft = points.FirstOrDefault(p => p.x == minX && p.y == maxY);
                    /// <summary>
                    /// BottomRight coordinates
                    /// </summary>
                    var BottomRight = points.FirstOrDefault(p => p.x == maxX && p.y == minY);

                    /// <summary>
                    /// fill robot list 
                    /// </summary>
                    robots.Add(new Robot
                    (
                       topLeft.x,
                        topLeft.y,
                        BottomRight.x,
                        BottomRight.y
                    ));

                });
            return robots;
        }
    }
}
