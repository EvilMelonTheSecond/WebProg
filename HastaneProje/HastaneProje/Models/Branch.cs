namespace HastaneProje.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Doctor> MainBranchDoctors { get; set; }

        // Navigation property for doctors in the polyclinic branch
        public ICollection<Doctor> PolyclinicDoctors { get; set; }
    }
}
