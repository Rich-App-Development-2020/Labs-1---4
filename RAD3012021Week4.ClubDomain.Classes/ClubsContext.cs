using ClubDomain.Classes.ClubModels;
using RAD3012021Week4.ClubDomain.Classes.Models;
using System.Data.Entity;

namespace Week32021ClubDomain.Classes
{
    public class ClubsContext : DbContext
    {
        public DbSet<Club> Clubs { get; set; }
        public DbSet<ClubEvent> ClubEvents { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<EventAttendance> EventAttendances { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public ClubsContext()
            : base("ClubConnection")
        {
        }
        public static ClubsContext Create()
        {
            return new ClubsContext();
        }

    }
}
