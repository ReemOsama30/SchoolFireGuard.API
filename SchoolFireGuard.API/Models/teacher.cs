namespace SchoolFireGuard.API.Models
{
    public class teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int pesentStudents { get; set; }
        public int absentStudents { get; set; }

        public bool done { get; set; } = false;
    }
}
