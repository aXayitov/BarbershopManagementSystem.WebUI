namespace BarbershopManagementSystem.WebUI.Models.Entity
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
