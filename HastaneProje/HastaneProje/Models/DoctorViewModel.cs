namespace HastaneProje.Models
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public int MainBranchId { get; set; }
        public int PolyclinicBranchId { get; set; }
    }
}
