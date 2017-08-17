using System.Collections.Generic;
using System.Web.Mvc;

namespace GeekHunter.Models
{
    public class DisplayCandidateViewModel
    {
        public List<Candidate> Candidates { get; set; }
        public List<SelectListItem> SkillListItems { get; set; }
        public int SkillId { get; set; }
        public int Id { get; set; }
    }
}