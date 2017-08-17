using System.Collections.Generic;
using System.Web.Mvc;

namespace GeekHunter.Repositories
{
    public interface ISkillRepository
    {
        List<SelectListItem> SkillListItems();
    }
}