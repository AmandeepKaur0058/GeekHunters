using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;
using GeekHunter.Controllers;
using Antlr.Runtime.Misc;

namespace GeekHunter.Models
{
    public class CreateCandidateViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Technology")]
        public int SkillId { get; set; }

        public List<SelectListItem> SkillListItems { get; set; }

        public string SearchTechnology { get; set; }
        public string Action
        {
            get
            {
                Expression<Func<HomeController, ActionResult>> update = (c => c.Update(this, Id));
                Expression<Func<HomeController, ActionResult>> create = (c => c.Create(this));

                var action = (Id!= 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }

    }
}