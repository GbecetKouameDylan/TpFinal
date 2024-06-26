﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TpFinal.Data;
using TpFinal.Models;

namespace TpFinal.Controllers
{
    public class HeroesController : Controller
    {
        private readonly HeroContext _context;

        public HeroesController(HeroContext context)
        {
            _context = context;
        }

        // GET: Heroes
        public async Task<IActionResult> Index()
        {
            var heroContext = await _context.VHeroDetails.ToListAsync();
            return View(heroContext);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AjouterHeroAComic(int heroId, int comicsId, DateTime dateAjout)
        {
            try
            {
                using (var connection = _context.Database.GetDbConnection() as SqlConnection)
                {
                    await connection.OpenAsync();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "AjouterHeroAComic";
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@HeroId", heroId);
                        command.Parameters.AddWithValue("@ComicsId", comicsId);
                        command.Parameters.AddWithValue("@DateAjout", dateAjout);

                        await command.ExecuteNonQueryAsync();
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest($"Une erreur s'est produite : {ex.Message}");
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Heroes == null)
            {
                return NotFound();
            }

            var hero = await _context.Heroes
                .Include(h => h.Identite)
                .Include(h => h.Pouvoir)
                .FirstOrDefaultAsync(m => m.HeroId == id);
            if (hero == null)
            {
                return NotFound();
            }

            return View(hero);
        }

        public IActionResult Create()
        {
            ViewData["IdentiteId"] = new SelectList(_context.Identites, "IdentiteId", "IdentiteId");
            ViewData["PouvoirId"] = new SelectList(_context.Pouvoirs, "PouvoirId", "PouvoirId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HeroId,Nom,PouvoirId,IdentiteId")] Hero hero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentiteId"] = new SelectList(_context.Identites, "IdentiteId", "IdentiteId", hero.IdentiteId);
            ViewData["PouvoirId"] = new SelectList(_context.Pouvoirs, "PouvoirId", "PouvoirId", hero.PouvoirId);
            return View(hero);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Heroes == null)
            {
                return NotFound();
            }

            var hero = await _context.Heroes.FindAsync(id);
            if (hero == null)
            {
                return NotFound();
            }
            ViewData["IdentiteId"] = new SelectList(_context.Identites, "IdentiteId", "IdentiteId", hero.IdentiteId);
            ViewData["PouvoirId"] = new SelectList(_context.Pouvoirs, "PouvoirId", "PouvoirId", hero.PouvoirId);
            return View(hero);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HeroId,Nom,PouvoirId,IdentiteId")] Hero hero)
        {
            if (id != hero.HeroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeroExists(hero.HeroId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentiteId"] = new SelectList(_context.Identites, "IdentiteId", "IdentiteId", hero.IdentiteId);
            ViewData["PouvoirId"] = new SelectList(_context.Pouvoirs, "PouvoirId", "PouvoirId", hero.PouvoirId);
            return View(hero);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Heroes == null)
            {
                return NotFound();
            }

            var hero
 = await _context.Heroes
                .Include(h => h.Identite)
                .Include(h => h.Pouvoir)
                .FirstOrDefaultAsync(m => m.HeroId == id);
            if (hero == null)
            {
                return NotFound();
            }

            return View(hero);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Heroes == null)
            {
                return Problem("Entity set 'HeroContext.Heroes'  is null.");
            }
            var hero = await _context.Heroes.FindAsync(id);
            if (hero != null)
            {
                _context.Heroes.Remove(hero);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeroExists(int id)
        {
            return (_context.Heroes?.Any(e => e.HeroId == id)).GetValueOrDefault();
        }
    }
}
