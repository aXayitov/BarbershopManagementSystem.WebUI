namespace BarbershopManagementSystem.WebUI.Models.Entity
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public TimeSpan? Duration { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
