namespace Domain.Entities
{
    public class CompletedTask
    {
        public int Id { get; set; }

        public DateTime CompletedAt { get; set; }

        public required Task Task { get; set; }
    }
}
