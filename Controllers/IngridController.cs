using ex_var1.Contexts;
using ex_var1.Models;
using Microsoft.AspNetCore.Mvc;

namespace ex_var1.Controllers
{
    [Route("api/IngridController")]
    [ApiExplorerSettings(GroupName = "v2")]
    public class IngridController : Controller
    {
        [HttpGet("get")]
        public ActionResult Get(string sort = "name")
        {

            IEnumerable<Ingrid> _ingr;
            using (var context = new IngridContext())
            {
                if (sort.ToLower() == "name")
                {
                    _ingr = context.Ingrid.OrderByDescending(x => x.name).ToList();
                }
                else
                {
                    _ingr = context.Ingrid.OrderBy(x => x.name).ToList();
                }
                return Json(_ingr);
            }
        }
        [HttpPost("add")]
        public ActionResult Add([FromForm] Ingrid pizza)
        {
            using (var context = new IngridContext())
            {
                context.Ingrid.Add(pizza);
                context.SaveChanges();
                return StatusCode(200, "Успешное добавление!");
            }
        }
        [HttpPut("put")]
        public ActionResult Change([FromForm] Ingrid pizza)
        {
            using (var context = new IngridContext())
            {
                var change = context.Ingrid.FirstOrDefault(x => x.id == pizza.id);
                change.name = pizza.name;
                change.ves = pizza.ves;
                change.cost = pizza.cost;
                context.SaveChanges();
                return StatusCode(200, "успешное изменение");
            }
        }
        [HttpDelete("del")]
        public ActionResult Delete([FromForm] Ingrid pizza)
        {
            using (var context = new IngridContext())
            {
                var delete = context.Ingrid.FirstOrDefault(x => x.id == pizza.id);
                context.Ingrid.Remove(delete);
                context.SaveChanges();
                return StatusCode(200, "Успешное удаление!");
            }
        }

    }
}
