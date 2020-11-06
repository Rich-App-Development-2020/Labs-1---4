namespace Week32021ClubDomain.Classes.Migrations
{
    using ClubDomain.Classes.ClubModels;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Week32021ClubDomain.Classes.ClubsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Week32021ClubDomain.Classes.ClubsContext context)
        {
            // Add a new club. If a club with the creation date (make sure it's unique for each club) 
            // does not exist otehrwise update the existing club. But related entities will not be updated
            // only club fields
            context.Clubs.AddOrUpdate(club => club.CreationDate, new Club[] {
               new Club
               {

                   ClubName = "Games Society",
                   CreationDate = DateTime.Parse("25/01/2020"),
                   clubMembers = new List<Member>()
                   {
                        new Member
                        {
                            StudentID = "S00000001",
                            approved = true
                        },

                        new Member
                        {
                            StudentID = "S00000002",
                            approved = true
                        }
                   },// End of new club members
                   clubEvents = new List<ClubEvent>()
                   {
				//start the event AFTER the club was created, pass 5 days, 15:00 hours
                         new ClubEvent { StartDateTime = DateTime.Parse("25/01/2020").Add(new TimeSpan(5,15,0,0,0)),
				//end the event one hour after you previously set the event start time
                                        EndDateTime =  DateTime.Parse("25/01/2020").Add(new TimeSpan(5,16,0,0,0)),
                            Location = "Sligo", Venue="Arena"
                        },
                        new ClubEvent { StartDateTime = DateTime.Parse("25/01/2020").Add(new TimeSpan(3,10,0,0,0)),
                                        EndDateTime =  DateTime.Parse("25/01/2020").Add(new TimeSpan(3,12,0,0,0)),
                            Location = "Sligo", Venue="Main Canteen"
                        },
                   }// End of new CLub events
               }, // End of First club added other clubs can be added next
            } // End of Clubs array
            );// End of Add or Update


            context.Clubs.AddOrUpdate(club => club.CreationDate, new Club[] {
               new Club
               {

                   ClubName = "Chess Club",
                   CreationDate = DateTime.Parse("5/02/2020"),
                   clubMembers = new List<Member>()
                   {
                        new Member
                        {
                            StudentID = "S00000003",
                            approved = true
                        },

                        new Member
                        {
                            StudentID = "S00000004",
                            approved = true
                        }
                   },// End of new club members
                   clubEvents = new List<ClubEvent>()
                   {
				//start the event AFTER the club was created, pass 5 days, 15:00 hours
                         new ClubEvent { StartDateTime = DateTime.Parse("5/02/2020").Add(new TimeSpan(5,18,0,0,0)),
				//end the event one hour after you previously set the event start time
                                        EndDateTime =  DateTime.Parse("5/02/2020").Add(new TimeSpan(5,19,0,0,0)),
                            Location = "Sligo", Venue="Room A0006"
                        },
                        new ClubEvent { StartDateTime = DateTime.Parse("5/02/2020").Add(new TimeSpan(3,10,0,0,0)),
                                        EndDateTime =  DateTime.Parse("5/02/2020").Add(new TimeSpan(3,12,0,0,0)),
                            Location = "Sligo", Venue="D Block Common Area (at the TV)"
                        },
                   }// End of new CLub events
               }, // End of First club added other clubs can be added next
            } // End of Clubs array
            );// End of Add or Update


            context.Clubs.AddOrUpdate(club => club.CreationDate, new Club[] {
               new Club
               {

                   ClubName = "Sligo IT Athletics Club",
                   CreationDate = DateTime.Parse("18/01/2020"),
                   clubMembers = new List<Member>()
                   {
                        new Member
                        {
                            StudentID = "S00000005",
                            approved = true
                        },

                        new Member
                        {
                            StudentID = "S00000006",
                            approved = true
                        }
                   },// End of new club members
                   clubEvents = new List<ClubEvent>()
                   {
				//start the event AFTER the club was created, pass 5 days, 15:00 hours
                         new ClubEvent { StartDateTime = DateTime.Parse("18/01/2020").Add(new TimeSpan(5,18,30,0,0)),
				//end the event one hour after you previously set the event start time
                                        EndDateTime =  DateTime.Parse("18/01/2020").Add(new TimeSpan(5,20,30,0,0)),
                            Location = "Sligo", Venue="Sligo IT Track"
                        },
                        new ClubEvent { StartDateTime = DateTime.Parse("25/01/2020").Add(new TimeSpan(3,10,0,0,0)),
                                        EndDateTime =  DateTime.Parse("25/01/2020").Add(new TimeSpan(3,12,0,0,0)),
                            Location = "Sligo", Venue="Knocknarea Arena"
                        },
                   }// End of new CLub events
               }, // End of First club added other clubs can be added next
            } // End of Clubs array
            );// End of Add or Update

            SeedEventAttendance(context);
        }

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
        }
    }
}
