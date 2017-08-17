using System.ComponentModel.DataAnnotations;

namespace GeekHunter.Models
{   
    public class Candidate
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int SkillId { get; set; }
       
        public string SkillName { get; set; }
        
    }
}