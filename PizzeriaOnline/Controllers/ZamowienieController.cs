﻿using System;
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
    public class ZamowienieController : ControllerBase
    {
        private s17763Context _con;
        public ZamowienieController(s17763Context con)
        {
            _con = con;
        }

        /// <summary>
        /// metoda pobierajaca wszystkie zamowienia
        /// </summary>
        /// <returns> lista zamowien </returns>
        [HttpGet]
        public IActionResult PobierzZamowienia()
        {
            return Ok(_con.Zamowienie.ToList());
        }

        /// <summary>
        /// metoda pobierajaca zamowienie o konkretnym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public IActionResult PobierzZamowienieById(int id)
        {
            Zamowienie pobranyKierownik = (Zamowienie)_con.Zamowienie.Where(x => x.IdZamowienia == id);
            if (pobranyKierownik == null)
            {
                return NotFound();

            }
            return Ok(pobranyKierownik);
        }
    }
}