using APi.Data;
using APi.Models;
using Microsoft.AspNetCore.Mvc;

namespace APi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenusController : ControllerBase
    {

        [HttpGet(Name = "GetMenus")]
        public List<TbMenu> Get()
        {
            DbDefaultContext db = new DbDefaultContext();
            var menus = db.TbMenus.ToList();
            return menus;
        }
    }
}
