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




    }
}