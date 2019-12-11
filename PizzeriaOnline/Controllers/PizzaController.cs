using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzeriaOnline.Models;

namespace PizzeriaOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {


        private s17763Context _con;
        public PizzaController(s17763Context con)
        {
            _con = con;
        }

        [HttpGet]
        public IActionResult PobierzPizze()
        {
            return Ok(_con.Pizza.ToList());
        }


        [HttpGet("{id:int}")]
        public IActionResult PobierzPizeById(int id)
        {
            Pizza pobranaPizza = (Pizza)_con.Pizza.Where(x => x.IdPizza == id);
            if (pobranaPizza == null)
            {
                return NotFound();

            }
            return Ok(pobranaPizza);
        }


        [HttpPost]
        public IActionResult ZapiszPizze(Pizza pizza)
        {
            _con.Add(pizza);
            _con.SaveChanges();
            return StatusCode(201, pizza);
        }


        [HttpDelete]
        public IActionResult UsunPizze(int id)
        {
            Pizza PizzaDoUsuniecia = (Pizza)_con.Pizza.Where(x => x.IdPizza == id);
            _con.Remove(PizzaDoUsuniecia);
            return StatusCode(204, PizzaDoUsuniecia);
        }
    }
}