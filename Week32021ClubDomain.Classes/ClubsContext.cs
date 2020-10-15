using ClubDomain.Classes.ClubModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week32021ClubDomain.Classes
{
    public class ClubsContext : DbContext
    {
        public DbSet<Club> Clubs { get; set; }
        public DbSet<ClubEvent> ClubEvents { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<EventAttendance> EventAttendances { get; set; }
        public ClubsContext()
            : base("DefaultConnection")
        {
        }
        public static ClubsContext Create()
        {
            return new ClubsContext();
        }

    }
}
