namespace SchoolFireGuard.API.DTOS.teacherDTOs
{
    public class addTeacherDTO
    {
        public string teacherName { get; set; }
        public int ClassID { get; set; }
        public int NoOfPresentStudents { get; set; }
        public int NoOfAbsentStudents { get; set; }

    }
}
