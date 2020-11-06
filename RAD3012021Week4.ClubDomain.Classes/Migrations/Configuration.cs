namespace RAD3012021Week4.ClubDomain.Classes.Migrations
{
    using CsvHelper;
    using global::ClubDomain.Classes.ClubModels;
    using RAD3012021Week4.ClubDomain.Classes.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<Week32021ClubDomain.Classes.ClubsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Week32021ClubDomain.Classes.ClubsContext context)
        {

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.


            //initialize two lists
            List<Student> students = new List<Student>();
            List<Course> courses = new List<Course>();
            courses = get_courses();


            context.Courses.AddOrUpdate(c => new { c.CourseCode, c.Year }, get_courses().ToArray());
            context.Students.AddOrUpdate(s => new { s.StudentID, s.FirstName, s.SecondName }, get_students().ToArray());



            #region AddChessClub

            context.Clubs.AddOrUpdate(club => club.CreationDate, new Club[] {
               new Club
               {

                   ClubName = "The Chess Club",
                   CreationDate = DateTime.Parse("25/01/2017"),
                   clubMembers = new List<Member>()
                   {
                        new Member
                        {
                            StudentID = "S00002529",
                            approved = true
                        },

                        new Member
                        {
                            StudentID = "S00023092",
                            approved = true
                        }
                   },// End of new club members
                   clubEvents = new List<ClubEvent>()
                   {
				//start the event AFTER the club was created, pass 5 days, 15:00 hours
                         new ClubEvent { StartDateTime = DateTime.Parse("25/01/2017").Add(new TimeSpan(6,17,0,0,0)),
				//end the event one hour after you previously set the event start time
                                        EndDateTime =  DateTime.Parse("25/01/2017").Add(new TimeSpan(6,21,0,0,0)),
                            Location = "IT Sligo", Venue="D1030"
                        },
                        new ClubEvent { StartDateTime = DateTime.Parse("25/01/2017").AddMonths(2).Add(new TimeSpan(0,13,0,0,0)),
                                        EndDateTime =  DateTime.Parse("25/01/2017").AddMonths(2).Add(new TimeSpan(0,14,0,0,0)),
                            Location = "IT Sligo", Venue="D1031"
                        },
                   }// End of new CLub events
               }, // End of First club added other clubs can be added next
            } // End of Clubs array
           );// End of Add or Update
            #endregion AddChessClub

            #region AddVolleyBallClub

            context.Clubs.AddOrUpdate(club => club.CreationDate, new Club[] {
               new Club
               {

                   ClubName = "Volley Ball Club",
                   CreationDate = DateTime.Parse("01/01/2018"),
                   clubMembers = new List<Member>()
                   {
                        new Member
                        {
                            StudentID = "S00046565",
                            approved = true
                        },

                        new Member
                        {
                            StudentID = "S00078018",
                            approved = true
                        }
                   },// End of new club members
                   clubEvents = new List<ClubEvent>()
                   {
				//start the event AFTER the club was created, pass 5 days, 15:00 hours
                         new ClubEvent { StartDateTime = DateTime.Parse("01/01/2018").AddMonths(1).Add(new TimeSpan(15,14,0,0,0)),
				//end the event one hour after you previously set the event start time
                                        EndDateTime =  DateTime.Parse("01/01/2018").AddMonths(1).Add(new TimeSpan(15,16,0,0,0)),
                            Location = "IT Sligo", Venue="Sports Arena"
                        },
                        new ClubEvent { StartDateTime = DateTime.Parse("01/01/2018").AddMonths(1).Add(new TimeSpan(25,16,0,0,0)),
                                        EndDateTime =  DateTime.Parse("01/01/2018").AddMonths(1).Add(new TimeSpan(25,19,0,0,0)),
                            Location = "Regional Sports Center", Venue="Main Hall"
                        },
                   }// End of new CLub events
               }, // End of First club added other clubs can be added next
            } // End of Clubs array
           );// End of Add or Update
            #endregion AddVolleyBallClub

            #region AddSoccerClub
            context.Clubs.AddOrUpdate(club => club.CreationDate, new Club[] {
               new Club
               {

                   ClubName = "Soccer Club",
                   CreationDate = DateTime.Parse("07/01/2018"),
                   clubMembers = new List<Member>()
                   {
                        new Member
                        {
                            StudentID = "S00113203",
                            approved = true
                        },

                        new Member
                        {
                            StudentID = "S00114203",
                            approved = true
                        }
                   },// End of new club members
                   clubEvents = new List<ClubEvent>()
                   {
				//start the event AFTER the club was created, pass 5 days, 15:00 hours
                         new ClubEvent { StartDateTime = DateTime.Parse("07/01/2018").AddMonths(10).Add(new TimeSpan(10,15,0,0,0)),
				//end the event one hour after you previously set the event start time
                                        EndDateTime =  DateTime.Parse("07/01/2018").AddMonths(10).Add(new TimeSpan(10,21,0,0,0)),
                            Location = "IT Sligo", Venue="Main Pitch"
                        },
                        new ClubEvent { StartDateTime = DateTime.Parse("07/01/2018").AddMonths(11).Add(new TimeSpan(5,18,0,0,0)),
                                        EndDateTime =  DateTime.Parse("07/01/2018").AddMonths(11).Add(new TimeSpan(5,19,0,0,0)),
                            Location = "Regional Sports Center", Venue="Astro Pitch"
                        },
                   }// End of new CLub events
               }, // End of First club added other clubs can be added next
            } // End of Clubs array
           );// End of Add or Update
            #endregion AddSoccerClub

            SeedEventAttendance(context);

        }
        #region AddEventAttendance
        private void SeedEventAttendance(Week32021ClubDomain.Classes.ClubsContext context)
        {
            List<Club> clubs = context.Clubs.ToList();
            //You can't iterate over a conext collection and chnage the context at the same time
            //Hence we need to take a copy of the culbs collection as a list#
            foreach (Club club in clubs)
                foreach (ClubEvent ev in club.clubEvents)
                    foreach (Member m in club.clubMembers)
                        context.EventAttendances.AddOrUpdate(a => new { a.EventID, a.AttendeeMember },
                            new EventAttendance
                            {
                                EventID = ev.EventID,
                                AttendeeMember = m.MemberID,
                            });
            context.SaveChanges();
            #endregion AddEventAttendance

        }
        private static List<Course> get_courses()
        {
            // Get the list of DTO records from the resource
            List<CourseDTO> cdto = Get<CourseDTO>("RAD3012021Week4.ClubDomain.Classes.Courses.csv"); // C: \Users\Dark Void\MyLab\RAD3012021Week4.ClubDomain.Classes\Courses.csv

            List<Course> Courses = new List<Course>();
            // iterate over the course DTO records and create course records for each one making the course year an intiger in the process
            // Dummy val
            int val;
            //for each record / row in the file create an object
            cdto.ForEach(rec =>
            {
                Courses.Add(
                  new Course
                  {
                      CourseCode = rec.CourseCode,
                      //changing the data so we can use it as a number,
                      //the method to replace the A is to get rid of dirty data, where an A is used to symbolize an apprenticeship
                      Year = Int32.TryParse(rec.Year.Trim('Y'), out val) ? val : (Int32.TryParse(rec.Year.Trim('A'), out val) ? val : 0),
                      CourseName = rec.Title
                  }
                  );
            });

            return Courses;

        }
        private static List<Student> get_students()
        {
            // Get the list of DTO records from the resource
            List<StudentDTO> sdto = Get<StudentDTO>("RAD3012021Week4.ClubDomain.Classes.StudentList1.csv");
            // C: \Users\Dark Void\MyLab\RAD3012021Week4.ClubDomain.Classes\StudentList1.csv
            List<Student> Students = new List<Student>();
            // iterate over the course DTO records and create course records for each one making the course year an intiger in the process
            // Dummy val
            int val;
            //for each record / row in the file create an object
            sdto.ForEach(rec =>
            {
                Students.Add(
                  new Student
                  {
                      StudentID = rec.StudentID,
                      FirstName = rec.FirstName,
                      SecondName = rec.LastName,
                  }
                  );
            });

            return Students;

        }
        public static List<T> Get<T>(string resourceName)
        {
            // Get the current assembly of the current executable project
            Assembly assembly = Assembly.GetExecutingAssembly();
            //creating a stream path based on the stream path passed down from the get_courses method
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {   // create a stream reader
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    // create a csv reader for the stream
                    CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
                    csvReader.Configuration.HasHeaderRecord = false;
                    return csvReader.GetRecords<T>().ToList();
                }
            }
        }
    }
}