using System.Data;
using Microsoft.Data.SqlClient;

namespace myapi.Data
{
    public class StudentRepository
    {
        private readonly Globals _globals;
        public StudentRepository(Globals globals) 
        { 
            this._globals = globals;
        }

        public bool StudentLogin(StudentLoginModel sm)
        {
            try
            {
                SqlCommand cmd = _globals.Connection();
                cmd.CommandText = "PR_Student_Login";
                cmd.Parameters.AddWithValue("@UserName", sm.UserName);
                cmd.Parameters.AddWithValue("@Password",sm.Password);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
                return false;            
            }                        
        }

        public IEnumerable<StudentModel> SelectAllStudent()
        {
            SqlCommand cmd = _globals.Connection();
            cmd.CommandText = "PR_Student_SelectAll";
            SqlDataReader reader = cmd.ExecuteReader();

            List<StudentModel> students = new List<StudentModel>();

            while (reader.Read())
            {
                StudentModel student = new StudentModel();
                student.StudentID = reader.GetInt32("StudentID");
                student.StudentName = reader.GetString("StudentName");
                student.StudentPhoneNumber = reader.GetString("StudentPhoneNumber");
                student.StudentEmail = reader.GetString("StudentEmail");
                student.StudentAddress = reader.GetString("StudentAddress");
                student.StudentGender = reader.GetString("StudentGender");
                student.StudentDOB = reader.GetDateTime("StudentDOB");
                student.StudentEducationStatus = reader.GetString("StudentEducationStatus");
                student.StudentInstituteName = reader.GetString("StudentInstituteName");
                student.EmergencyContactNumber = reader.GetString("EmergencyContactNumber");
                student.StudentCity = reader.GetString("StudentCity");
                student.StudentState = reader.GetString("StudentState");
                student.StudentCountry = reader.GetString("StudentCountry");
                student.StudentPincode = reader.GetString("StudentPincode");
                student.GuardianName = reader.GetString("GuardianName");
                student.GuardianPhoneNumber = reader.GetString("GuardianPhoneNumber");
                student.AdmissionDate = reader.GetDateTime("AdmissionDate");
                student.ProfileImage = reader.GetString("ProfileImage");
                student.StudentPassword = reader.GetString("StudentPassword");
                student.RoomID = reader.GetInt32("RoomID");
                student.HostelID = reader.GetInt32("HostelID");
                student.IsDeleted = reader.GetBoolean("IsDeleted");
                student.CreatedAt = reader.GetDateTime("CreatedAt");
                student.UpdatedAt = reader.GetDateTime("UpdatedAt");
                student.HostelName = reader.GetString("HostelName");
                student.RoomNumber = reader.GetString("RoomNumber");
                students.Add(student);
            }
            return students;
        }

        public bool StudentDelete(int id)
        {
            try
            {
                SqlCommand cmd = _globals.Connection();
                cmd.CommandText = "PR_Student_Delete";
                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                return false;
                Console.WriteLine(ex.Message);
            }
        }

        public StudentModel StudentSelectByID(int id)
        {
            SqlCommand cmd = _globals.Connection();
            cmd.CommandText = "PR_Student_SelectAll";
            SqlDataReader reader = cmd.ExecuteReader();
            cmd.Parameters.AddWithValue("StudentID", id);

            StudentModel student = new StudentModel();
           
            student.StudentID = reader.GetInt32("StudentID");
            student.StudentName = reader.GetString("StudentName");
            student.StudentPhoneNumber = reader.GetString("StudentPhoneNumber");
            student.StudentEmail = reader.GetString("StudentEmail");
            student.StudentAddress = reader.GetString("StudentAddress");
            student.StudentGender = reader.GetString("StudentGender");
            student.StudentDOB = reader.GetDateTime("StudentDOB");
            student.StudentEducationStatus = reader.GetString("StudentEducationStatus");
            student.StudentInstituteName = reader.GetString("StudentInstituteName");
            student.EmergencyContactNumber = reader.GetString("EmergencyContactNumber");
            student.StudentCity = reader.GetString("StudentCity");
            student.StudentState = reader.GetString("StudentState");
            student.StudentCountry = reader.GetString("StudentCountry");
            student.StudentPincode = reader.GetString("StudentPincode");
            student.GuardianName = reader.GetString("GuardianName");
            student.GuardianPhoneNumber = reader.GetString("GuardianPhoneNumber");
            student.AdmissionDate = reader.GetDateTime("AdmissionDate");
            student.ProfileImage = reader.GetString("ProfileImage");
            student.StudentPassword = reader.GetString("StudentPassword");
            student.RoomID = reader.GetInt32("RoomID");
            student.HostelID = reader.GetInt32("HostelID");
            student.IsDeleted = reader.GetBoolean("IsDeleted");
            student.CreatedAt = reader.GetDateTime("CreatedAt");
            student.UpdatedAt = reader.GetDateTime("UpdatedAt");
            student.HostelName = reader.GetString("HostelName");
            student.RoomNumber = reader.GetString("RoomNumber");  
            
            return student;
        }

        public bool StudentInsert(StudentModel student)
        {
            try
            {
                SqlCommand cmd = _globals.Connection();
                cmd.CommandText = "PR_Student_Insert";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentName", student.StudentName);
                cmd.Parameters.AddWithValue("@StudentPhoneNumber", student.StudentPhoneNumber);
                cmd.Parameters.AddWithValue("@StudentEmail", student.StudentEmail);
                cmd.Parameters.AddWithValue("@StudentAddress", student.StudentAddress);
                cmd.Parameters.AddWithValue("@StudentGender", student.StudentGender);
                cmd.Parameters.AddWithValue("@StudentDOB", student.StudentDOB);
                cmd.Parameters.AddWithValue("@StudentEducationStatus", student.StudentEducationStatus);
                cmd.Parameters.AddWithValue("@StudentInstituteName", student.StudentInstituteName);
                cmd.Parameters.AddWithValue("@EmergencyContactNumber", student.EmergencyContactNumber);
                cmd.Parameters.AddWithValue("@StudentCity", student.StudentCity);
                cmd.Parameters.AddWithValue("@StudentState", student.StudentState);
                cmd.Parameters.AddWithValue("@StudentCountry", student.StudentCountry);
                cmd.Parameters.AddWithValue("@StudentPincode", student.StudentPincode);
                cmd.Parameters.AddWithValue("@GuardianName", student.GuardianName);
                cmd.Parameters.AddWithValue("@GuardianPhoneNumber", student.GuardianPhoneNumber);
                cmd.Parameters.AddWithValue("@AdmissionDate", student.AdmissionDate);
                cmd.Parameters.AddWithValue("@ProfileImage", student.ProfileImage);
                cmd.Parameters.AddWithValue("@RoomID", student.RoomID);
                cmd.Parameters.AddWithValue("@HostelID", student.HostelID);
                
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {                
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public bool StudentUpdate(int id,StudentModel student)
        {
            try
            {
                SqlCommand cmd = _globals.Connection();
                cmd.CommandText = "PR_Student_Update";
                cmd.CommandType = CommandType.StoredProcedure;
               
                cmd.Parameters.AddWithValue("@StudentID", id);
                cmd.Parameters.AddWithValue("@StudentName", student.StudentName);
                cmd.Parameters.AddWithValue("@StudentPhoneNumber", student.StudentPhoneNumber);
                cmd.Parameters.AddWithValue("@StudentEmail", student.StudentEmail);
                cmd.Parameters.AddWithValue("@StudentAddress", student.StudentAddress);
                cmd.Parameters.AddWithValue("@StudentGender", student.StudentGender);
                cmd.Parameters.AddWithValue("@StudentDOB", student.StudentDOB);
                cmd.Parameters.AddWithValue("@StudentEducationStatus", student.StudentEducationStatus);
                cmd.Parameters.AddWithValue("@StudentInstituteName", student.StudentInstituteName);
                cmd.Parameters.AddWithValue("@EmergencyContactNumber", student.EmergencyContactNumber);
                cmd.Parameters.AddWithValue("@StudentCity", student.StudentCity);
                cmd.Parameters.AddWithValue("@StudentState", student.StudentState);
                cmd.Parameters.AddWithValue("@StudentCountry", student.StudentCountry);
                cmd.Parameters.AddWithValue("@StudentPincode", student.StudentPincode);
                cmd.Parameters.AddWithValue("@GuardianName", student.GuardianName);
                cmd.Parameters.AddWithValue("@GuardianPhoneNumber", student.GuardianPhoneNumber);
                cmd.Parameters.AddWithValue("@AdmissionDate", student.AdmissionDate);
                cmd.Parameters.AddWithValue("@ProfileImage", student.ProfileImage);
                cmd.Parameters.AddWithValue("@RoomID", student.RoomID);
                cmd.Parameters.AddWithValue("@HostelID", student.HostelID);
                
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {                
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }
}
