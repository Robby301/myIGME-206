using System;
using System.Collections.Generic;

namespace CourseLib
{
    // Class: Schedule
    // Author: Robert Gregory Disbrow
    // Purpose: set up DateTime variables startTime and endTime, and also set up the list daysOfWeek
    //          with DayOfWeek as the list type
    // Restrictions: None
    public class Schedule
    {
        public DateTime startTime;
        public DateTime endTime;

        public List<DayOfWeek> daysOfWeek = new List<DayOfWeek>();
    }

    // Class: Courses
    // Author: Robert Gregory Disbrow
    // Purpose: Set up the sorted list with Course as the type, and string as the key for comparisson
    //          There is also a Courses default constructor that creates a list of 100 courses
    //          Then there is an indexer property for course and courseCode
    //          Finally there is a remove method
    // Restrictions: None
    public class Courses
    {
        SortedList<string, Course> sortedList = new SortedList<string, Course>();

        public Courses()
        {
            Course thisCourse;
            Schedule thisSchedule;

            Random rand = new Random();

            // generate courses IGME-200 through IGME-299
            for (int i = 200; i < 300; ++i)
            {
                // use constructor to create new course object with code and description
                thisCourse = new Course(($"IGME-{i}"), ($"Description for IGME-{i}"));

                // create a new Schedule object
                thisSchedule = new Schedule();
                for (int dow = 0; dow < 7; ++dow)
                {
                    // 50% chance of the class being on this day of week
                    if (rand.Next(0, 2) == 1)
                    {
                        // add to the daysOfWeek list
                        thisSchedule.daysOfWeek.Add((DayOfWeek)dow);

                        // select random hour of day
                        int nHour = rand.Next(0, 24);

                        // set start and end times of minute duration
                        // select fixed date to allow time calculations
                        thisSchedule.startTime = new DateTime(1, 1, 1, nHour, 0, 0);
                        thisSchedule.endTime = new DateTime(1, 1, 1, nHour, 50, 0);
                    }
                }

                // set the schedule for this course
                thisCourse.schedule = thisSchedule;

                // add this course to the SortedList
                this[thisCourse.courseCode] = thisCourse;
            }
        }

        public Course this[string courseCode]
        {
            get
            {
                Course returnVal;
                try
                {
                    returnVal = (Course)sortedList[courseCode];
                }
                catch
                {
                    returnVal = null;
                }

                return (returnVal);
            }

            set
            {
                try
                {
                    sortedList[courseCode] = value;
                }
                catch
                {

                }
            }
        }

        public void Remove(string courseCode)
        {
            if (courseCode != null)
            {
                sortedList.Remove(courseCode);
            }
        }
    }

    // Class: Course
    // Author: Robert Gregory Disbrow
    // Purpose: This class sets up 3 string variables (courseCode, description, and teacherEmail) and
    //          a schedule object just called schedule
    //          Then there is a default constructor, then there is another constructor that is needed
    //          for the indexer
    // Restrictions: None
    public class Course
    {
        public string courseCode;
        public string description;
        public string teacherEmail;
        public Schedule schedule;

        public Course()
        {

        }
        public Course(string courseCode, string description)
        {
            this.courseCode = courseCode;
            this.description = description;
        }
    }
}