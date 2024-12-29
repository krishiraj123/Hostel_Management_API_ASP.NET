using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace myapi.Models
{
    public class RoomModel
    {       
        [Key]
        public int RoomID { get; set; }
                
        public string RoomNumber { get; set; }
        
        public int RoomCapacity { get; set; }
        
        public int CurrentVacancy { get; set; }
        
        public int RoomFloor { get; set; }
        
        public int RoomRent { get; set; }        
        
        public string RoomType { get; set; }        
        
        public string RoomStatus { get; set; }

        public bool IsDeleted { get; set; }
        
        public int HostelID { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        
        public string HostelName { get; set; }
    }

}

