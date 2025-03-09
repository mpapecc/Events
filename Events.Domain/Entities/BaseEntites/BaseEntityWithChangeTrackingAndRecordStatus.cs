using Events.Common.Enums;

namespace Events.Domain.Entities.BaseEntites
{
    public abstract class BaseEntityWithChangeTrackingAndRecordStatus : BaseEntity
    {
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}
