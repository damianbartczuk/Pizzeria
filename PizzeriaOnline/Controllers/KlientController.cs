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
    public class KlientController : ControllerBase
    {
        private s17763Context _con;
        public KlientController(s17763Context con)
        {
            _con = con;
        }

        /// <summary>
        /// metoda do pobrania klientów
        /// </summary>
        /// <returns>
        /// liste klientow
        /// </returns>
        [HttpGet]
        public IActionResult PobierzKlientowo()
        {
            return Ok(_con.Klient.ToList());
        }


        /// <summary>
        /// metoda pobierajaca konkretnego klienta 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public IActionResult PobierzKlientowoById(int id)
        {
            Klient pobranyKlient = (Klient)_con.Klient.Where(x => x.IdKlienta == id);
            if (pobranyKlient == null)
            {
                return NotFound(); 
                
            }
            return Ok(pobranyKlient);
        }

        /// <summary>
        /// metoda do zapisania klienta
        /// </summary>
        /// <param name="k"></param>
        /// <returns>
        /// zapisany klint
        /// </returns>

        [HttpPost]
        public IActionResult ZapisKlienta(Klient k)
        {
            _con.Klient.Add(k);
            _con.SaveChanges();
            return Ok();
        }
    }
}