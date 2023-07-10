namespace SP_ProjectCalling.Models.Domain
{
    public class Supervisor
    {
        public int SupervisorId { get; set; }
        public string Name { get; set; }
        public string? TodaysTask { get; set; }
        public bool IsActive { get; set; }

    }
}
