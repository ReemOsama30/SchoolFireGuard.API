namespace SchoolFireGuard.API.DTOS.teacherDTOs
{
    public class GetTeachersDTO
    {
        public string Name { get; set; }
        public int classID { get; set; }
        public string ClassName { get; set; }
        public int PesentStudents { get; set; }
        public int AbsentStudents { get; set; }
        public bool Done { get; set; }
    }
}