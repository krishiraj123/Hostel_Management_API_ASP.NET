using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace myapi.Models
{
    public class HostelModel
    {             
        public int? HostelID { get; set; } 

        public string HostelName { get; set; }

        public string HostelAddress { get; set; }

        public string HostelContactNumber { get; set; }

        public string HostelEmail { get; set; }

        public string HostelAdminPassword { get; set; }
       
        public string HostelPincode { get; set; }
       
        public string HostelCity { get; set; }
       
        public string HostelState { get; set; }
       
        public string HostelCountry { get; set; }
       
        public int HostelCapacity { get; set; }
       
        public string Amenities { get; set; }
       
        public string HostelPolicies { get; set; }
       
        public string HostelType { get; set; } 
             
        public DateTime CreatedAt { get; set; } = DateTime.Now;
             
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

    public class HostelLoginModel()
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class HostelUpdatePasswordModel()
    {
        public int HostelID{ get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}

