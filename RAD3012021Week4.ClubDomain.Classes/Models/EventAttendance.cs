using RAD3012021Week4.ClubDomain.Classes.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubDomain.Classes.ClubModels
{
    public class EventAttendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ForeignKey("associatedEvent")]
        public int EventID { get; set; }
        [ForeignKey("memberAttending")]
        // Set Nullable to avoid cascading deletes 
        // which would lead to indirect circular deletes
        public int? AttendeeMember { get; set; }
        public virtual Member memberAttending { get; set; }
        public virtual ClubEvent associatedEvent { get; set; }
    }
}
