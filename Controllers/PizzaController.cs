using ex_var1.Contexts;
using ex_var1.Models;
using ex_var1.Pages.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ex_var1.Controllers
{
    [Route("api/PizzaController")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class PizzaController : Controller
    {
        [HttpGet("get")]
        public ActionResult Get(string sort = "ves")
        {

            IEnumerable<Pizza> _pizza;
            using (var context = new PizzaContext())
            {
                if (sort.ToLower() == "ves")
                {
                    _pizza = context.Pizza.OrderByDescending(x => x.ves).ToList();
                }
                else {
                    _pizza = context.Pizza.OrderBy(x => x.ves).ToList();
                }
                return Json(_pizza);
            }
        }
        [HttpPost("add")]
        public ActionResult Add([FromForm] Pizza pizza)
        {
            using (var context = new PizzaContext())
            {
                context.Pizza.Add(pizza);
                context.SaveChanges();
                return StatusCode(200, "Успешное добавление!");
            }
        }
        [HttpPut("put")]
        public ActionResult Change([FromForm] Pizza pizza)
        {
            using (var context = new PizzaContext())
            {
                var change = context.Pizza.FirstOrDefault(x => x.id == pizza.id);
                change.name = pizza.name;
                change.description = pizza.description;
                change.sostav = pizza.sostav;
                change.ves = pizza.ves;
                change.size = pizza.size;
                change.cost = pizza.cost;
                context.SaveChanges();
                return StatusCode(200, "успешное изменение");
            }
        }
        [HttpDelete("del")]
        public ActionResult Delete([FromForm] Pizza pizza)
        {
            using (var context = new PizzaContext())
            {
                var delete = context.Pizza.FirstOrDefault(x => x.id == pizza.id);
                context.Pizza.Remove(delete);
                context.SaveChanges();
                return StatusCode(200, "Успешное удаление!");
            }
        }
        

    }
}
