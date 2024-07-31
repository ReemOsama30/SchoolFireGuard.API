namespace SchoolFireGuard.API.DTOS.teacherDTOs
{
    public class addTeacherDTO
    {
        public string Name { get; set; }
        public int classID { get; set; }
        public int pesentStudents { get; set; }
        public int absentStudents { get; set; }

    }
}
