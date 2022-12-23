using NfiCodeAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NfiCodeAssignment.Utility
{
    public  class Parser
    {
        readonly List<string> lines;
        List<RobotCoordinate> originList;
        List<RobotTimeStep> timeStepList;

        public Parser(string schedule)
        {
            lines = ParseScheduleInputLines(schedule);
        }

        /// <summary>
        /// The create schedule model after parse file and finish MakeSchedule 
        /// </summary>
        /// <returns>The Schedule model</returns>
        public Schedule GetSchedule() 
        {
            return new Schedule
            {
                RobotCoordinates = MakeSchedule()
            };
        }

        /// <summary>
        /// make shadule  after pars file.The RobotCoordinate model is store origin point and The RobotTimeStep model is store timesteps.
        /// this model help us for calculate other coordinates of robot and find overlapping
        /// RobotCoordinate class is contains robot orinig point and a list of timeSteps object because we have list of Timesteps for every robot.
        /// </summary>
        /// <returns>The list of RobotCoordinate model</returns>
        private List<RobotCoordinate> MakeSchedule()
        {
            /// <summary>
            /// Fill list of RobotTimeStep model for add to every RobotCoordinate model
            /// </summary>
            CreateRobotTimeSteps();
            /// <summary>
            /// Fill list of RobotCoordinate model whitout TimeSteps list
            /// </summary>
            CreateRobotOrigin();
            /// <summary>
            /// Fill TimeSteps List of every RobotCoordinate Model
            /// </summary>
            originList.ForEach(o => o.TimeSteps.AddRange(timeStepList.Where
                (t => t.RobotId.Equals(o.RobotId))));

            return originList;
        }

        /// <summary>
        /// The make Robot Coordinate ans other data after parsed file according to file's format
        /// </summary>
        /// <returns>The list of RobotCoordinate model</returns>
        private List<RobotCoordinate> CreateRobotOrigin()
        {
            originList = new List<RobotCoordinate>();
            /// <summary>
            /// The start of this loop is index number 2, because index number 0, is The number of robots and index number 1, is The number of time steps according to File.
            /// </summary>
            for (int j = 2; j < lines.Count; j++)
            {
                var line = lines[j].Split(',').ToArray();
                RobotCoordinate originRobot;
                /// <summary>
                /// according to the file the data about TimeSteps has 3 length 
                /// </summary>
                if (line.Length == 3)
                {
                    originRobot = new RobotCoordinate
                    {
                        RobotId = line[0].Trim(),
                        Point =
                         new Point { x = Convert.ToInt32(line[1]), y = Convert.ToInt32(line[2]) },
                        TimeSteps = new List<RobotTimeStep>()
                    };
                    originList.Add(originRobot);
                }
            }
            return originList;
        }

        /// <summary>
        ///The make Robot TimesSteps after parsed file according to file's format
        /// </summary>
        /// <returns>The list of RobotTimeStep</returns>
        private List<RobotTimeStep> CreateRobotTimeSteps()
        {
            timeStepList = new List<RobotTimeStep>();

            for (int j = 2; j < lines.Count; j++)
            {
                /// <summary>
                /// The start of this loop is index number 2, because index number 0, is The number of robots and index number 1, is The number of time steps according to File.
                /// </summary>
                var line = lines[j].Split(',').ToArray();

                /// <summary>
                /// according to the file the data about TimeSteps has 4 length 
                /// </summary>
                if (line.Length == 4)
                {
                    var timeStepRobot = new RobotTimeStep
                    {
                        TimeStep = Convert.ToInt32(line[0]),
                        RobotId = line[1].Trim(),
                        Point = new Point
                        {
                            x = Convert.ToInt32(line[2]),
                            y = Convert.ToInt32(line[3])
                        }
                    };
                    timeStepList.Add(timeStepRobot);
                }
            }
            return timeStepList;
        }

        /// <summary>
        /// Extracts the lines from the schedule string.
        /// Removes all comments and empty lines.
        /// </summary>
        private List<string> ParseScheduleInputLines(string schedule)
        {
            return schedule
                .Replace("\r\n", "\n")
                .Split('\n')
                .Where(x => !string.IsNullOrWhiteSpace(x) && !x.StartsWith("#"))
                .ToList();
        }

        /// <summary>
        /// Get TimeStep of parsed file
        /// </summary>
        /// <returns> return TimeStep value</returns>
        public int GetTimeStep()
        {
            return Convert.ToInt32(lines[1]);
        }

    }
}
