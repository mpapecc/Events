using Events.Domain.Entities.BaseEntites;

namespace Events.Domain.Entities
{
    public class Event : BaseEntityWithChangeTrackingAndRecordStatus
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
    }
}
