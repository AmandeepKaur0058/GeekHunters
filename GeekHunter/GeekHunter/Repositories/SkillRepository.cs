using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Dapper;
using GeekHunter.Database;

namespace GeekHunter.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        public  List<SelectListItem> SkillListItems()
        {
            using (var cnn = DatabaseManager.SimpleDbConnection())
            {
                return cnn.Query<SelectListItem>(@"SELECT Name As Text ,Id As Value
                                                          FROM Skill").ToList();
            }
        }
    }
}