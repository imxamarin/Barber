using Barbershop.PCL.Types;
using System;


namespace InstaBiz.Model
{
    public class CalEvent 
    {
        public string Id { get; set; }
        public RefType RefType { get; set; }
        public string ParentID { get; set; }
        public string WorkflowEntryID { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public int AlarmMinutes { get; set; }
        public string UserID { get; set; }
        public bool IsPrivate { get; set; }
        public bool AutoClear { get; set; }
        public string Location { get; set; }
        public string LiveEventID { get; set; }
        public string CompanyID { get; set; }    
        public string UserName { get; set; }
        public string Permissions { get; set; }

    }
}
