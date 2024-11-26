using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CalendarSchedule.Domain.Models
{
    public class Attendee
    {
        [IgnoreDataMember]
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public bool IsAttending { get; set; }
        [IgnoreDataMember]
        [JsonIgnore]
        [ForeignKey("EventId")]
        public int EventId { get; set; }
    }
}
