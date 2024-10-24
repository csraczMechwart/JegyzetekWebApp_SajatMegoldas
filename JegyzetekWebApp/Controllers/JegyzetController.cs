﻿using JegyzetekWebApp.Data;
using JegyzetekWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JegyzetekWebApp.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class JegyzetController : Controller
    {
        private readonly TodolistDbContext _db;
        public JegyzetController(TodolistDbContext db)
        {
            _db = db;
        }

        [Route("ujkartya/{kartyaNev}")]
        [HttpPost("{kartyaNev}")]
        public async Task<ActionResult> UjKartya(string kartyaNev)
        {
            var ujKartya = new Kartya() { Nev = kartyaNev };
            _db.Kartyak.Add(ujKartya);
            await _db.SaveChangesAsync();
            return Ok();
        }
        [Route("ujTeendo/{teendoTartalom}/{kartyaId}")]
        [HttpPost("{teendoTartalom},{kartyaId}")]
        public async Task<ActionResult> UjTeendo(string teendoTartalom, int kartyaId)
        {
            var ujTeendo = new Teendo();
            ujTeendo.KartyaId = kartyaId;
            ujTeendo.Tartalom = teendoTartalom;
            ujTeendo.Letrehozve = DateTime.Now;
            ujTeendo.Modositva = DateTime.Now;
            ujTeendo.Kesz = false;
            _db.Teendok.Add(ujTeendo);
            await _db.SaveChangesAsync();
            return Ok();
        }
        [Route("teendoTorlese/{teendoId}")]
        [HttpDelete("{teendoId}")]
        public async Task<ActionResult> TeendoTorlese(int teendoId)
        {
            var teendo = _db.Teendok.Find(teendoId);
            if(teendo == null)
            {
                return NotFound();
            }
            _db.Teendok.Remove(teendo);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [Route("kartyaTorlese/{kartyaId}")]
        [HttpDelete("{kartyaId}")]
        public async Task<ActionResult> KartyaTorlese(int kartyaId)
        {
            var kartya = _db.Kartyak.Find(kartyaId);
            if (kartya == null)
            {
                return NotFound();
            }
            var teendok = _db.Teendok.Where(x => x.KartyaId == kartyaId).ToList();
            foreach (var t in teendok)
            {
                _db.Teendok.Remove(t);
            }
            _db.Kartyak.Remove(kartya);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [Route("Kesz/{teendoId}")]
        [HttpDelete("{teendoId}")]
        public async Task<ActionResult> TeendoKesz(int teendoId)
        {
            var teendo = _db.Teendok.Find(teendoId);
            if (teendo == null)
            {
                return NotFound();
            }
            if(!teendo.Kesz)
                teendo.Kesz = true;
            else
                teendo.Kesz = false;
            _db.Entry(teendo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
