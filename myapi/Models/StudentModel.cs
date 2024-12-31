using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class StudentModel
{    
    public int? StudentID { get; set; }

    
    public string StudentName { get; set; }

    
    public string StudentPhoneNumber { get; set; }

    
    
    public string StudentEmail { get; set; }

    
    public string StudentAddress { get; set; }

    
    
    public string StudentGender { get; set; }

    
    public DateTime StudentDOB { get; set; }

    
    public string StudentEducationStatus { get; set; } // E.g., School/College/Working

    
    public string StudentInstituteName { get; set; }

    
    
    public string EmergencyContactNumber { get; set; }

    
    public string StudentCity { get; set; }

    
    public string StudentState { get; set; }

    
    public string StudentCountry { get; set; }

    
    
    public string StudentPincode { get; set; }

    
    public string GuardianName { get; set; }

    
    
    public string GuardianPhoneNumber { get; set; }

    
    public DateTime AdmissionDate { get; set; }

    public string ProfileImage { get; set; } 

    
    public string StudentPassword { get; set; }

        
    public int RoomID { get; set; }

        
    public int HostelID { get; set; }

    public bool IsDeleted { get; set; } = false;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    [Newtonsoft.Json.JsonIgnore]
    public string? HostelName { get; set; }
    [Newtonsoft.Json.JsonIgnore]
    public string? RoomNumber { get; set; }
}

public class StudentAddEditModel
{    
    public int? StudentID { get; set; }


    public string StudentName { get; set; }


    public string StudentPhoneNumber { get; set; }



    public string StudentEmail { get; set; }


    public string StudentAddress { get; set; }



    public string StudentGender { get; set; }


    public DateTime StudentDOB { get; set; }


    public string StudentEducationStatus { get; set; } // E.g., School/College/Working


    public string StudentInstituteName { get; set; }



    public string EmergencyContactNumber { get; set; }


    public string StudentCity { get; set; }


    public string StudentState { get; set; }


    public string StudentCountry { get; set; }



    public string StudentPincode { get; set; }


    public string GuardianName { get; set; }



    public string GuardianPhoneNumber { get; set; }


    public DateTime AdmissionDate { get; set; }

    public string ProfileImage { get; set; }


    public string StudentPassword { get; set; }


    public int RoomID { get; set; }


    public int HostelID { get; set; }

    //public bool IsDeleted { get; set; }

    //public DateTime CreatedAt { get; set; } = DateTime.Now;

    //public DateTime UpdatedAt { get; set; } = DateTime.Now;
}

public class StudentLoginModel
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
