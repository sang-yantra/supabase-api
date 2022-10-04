namespace Supabase.Microservices.DTO
{
    public class TaskInfoDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? Priority { get; set; }
        public long? OriginalEstimate { get; set; }
        public long? Completed { get; set; }
    }
}
