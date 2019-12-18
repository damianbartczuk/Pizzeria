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

        /// <summary>
        /// metoda poierająca wszystkie pizze
        /// </summary>
        /// <returns> lista pizz </returns>
        [HttpGet]
        public IActionResult PobierzPizze()
        {
            return Ok(_con.Pizza.ToList());
        }

        /// <summary>
        /// meoda pobierajaca pizze z konkretnym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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


        /// <summary>
        /// metoda zapisujaca pizze
        /// </summary>
        /// <param name="pizza"></param>
        /// <returns> zapisana pizza </returns>
        [HttpPost]
        public IActionResult ZapiszPizze(Pizza pizza)
        {
            _con.Add(pizza);
            _con.SaveChanges();
            return StatusCode(201, pizza);
        }

        /// <summary>
        /// metoda usuwajaca pizze o konkretnym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> usunieta pizza </returns>
        [HttpDelete]
        public IActionResult UsunPizze(int id)
        {
            Pizza PizzaDoUsuniecia = (Pizza)_con.Pizza.Where(x => x.IdPizza == id);
            _con.Remove(PizzaDoUsuniecia);
            return StatusCode(204, PizzaDoUsuniecia);
        }
    }
}