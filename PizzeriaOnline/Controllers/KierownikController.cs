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
    public class KierownikController : ControllerBase
    {

        private s17763Context _con;
        public KierownikController(s17763Context con)
        {
            _con = con;
        }

        /// <summary>
        /// metoda jest endpointem do pobrania kierowników
        /// </summary>
        /// <returns>
        /// Meoda zwaca istniejących kierowniów
        /// </returns>
        [HttpGet]
        public IActionResult PobierzKierownikow()
        {
            return Ok(_con.Kierownik.ToList());
        }

        /// <summary>
        /// metoda jest endpointem do pobrania kierownika o zdefiniowanym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public IActionResult PobierzKierownikaById(int id)
        {
            Kierownik pobranyKierownik = (Kierownik)_con.Kierownik.Where(x => x.IdKierownika == id);
            if (pobranyKierownik == null)
            {
                return NotFound();

            }
            return Ok(pobranyKierownik);
        }



    }
}