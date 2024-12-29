namespace myapi.Models
{
    public class ComplaintsModel
    {
        public int? ComplainID { get; set; }
        public string ComplainSubject { get; set; }
        public string ComplainBody { get; set; }
        public string ComplainStatus { get; set; }
        public int HostelID { get; set; }
        public int RoomID { get; set; }
        public int StudentID { get; set; }           
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string HostelName { get; set; }
        public string RoomNumber { get; set; }
        public string StudentName { get; set; }
    }

    public class ComplaintsList
    {
        public int ComplainID { get; set; }
        public int StudentID { get; set; }
        public int RoomID { get; set; }
        public int HostelID { get; set; }
        public string ComplainSubject { get; set; }
        public string ComplainBody { get; set; }
        public string ComplainStatus { get; set; }
        public string HostelName { get; set; }
        public string RoomNumber { get; set; }
        public string StudentName { get; set; }
    }

    public class ComplainAddEditModel
    {
        public int? ComplainID { get; set; }
        public int StudentID { get; set; }
        public int HostelID { get; set; }
        public int RoomID { get; set; }
        public string ComplainSubject { get; set; }
        public string ComplainBody { get; set; }
    }

    public class ComplainUpdateStatusModel
    {
        public int ComplainID { get; set; }
        public string ComplainStatus { get; set; }
    }
}
