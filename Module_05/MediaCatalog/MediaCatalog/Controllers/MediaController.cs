using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MediaCatalog.Models;
using System.Web;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace MediaCatalog.Controllers
{
    public class MediaController : Controller
    {
        private readonly MediaContext _context;

        public MediaController(MediaContext context)
        {
            _context = context;
        }

        // GET: Media
        public async Task<IActionResult> Index(string sortOrder)
        {
			ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
			ViewData["TypeSortParm"] = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";

			var medias = from m in _context.Medias select m;

			switch(sortOrder)
			{
				case "title_desc":
					medias = medias.OrderByDescending(m => m.Title);
					break;
				case "type_desc":
					medias = medias.OrderByDescending(m => m.MediaType);
					break;
				default:
					medias = medias.OrderBy(m => m.Title);
					break;
			}
			return View(await medias.AsNoTracking().ToListAsync());
        }

        // GET: Media/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var media = await _context.Medias
                .SingleOrDefaultAsync(m => m.ID == id);
            if (media == null)
            {
                return NotFound();
            }

            return View(media);
        }

        // GET: Media/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Media/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,MediaType,Format,Duration,Genre,Year,Rating,Location,Notes")] Media media)
        {
            if (ModelState.IsValid)
            {
                _context.Add(media);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(media);
        }

        // GET: Media/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var media = await _context.Medias.SingleOrDefaultAsync(m => m.ID == id);
            if (media == null)
            {
                return NotFound();
            }
            return View(media);
        }

        // POST: Media/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,MediaType,Format,Duration,Genre,Year,Rating,Location,Notes")] Media media)
        {
            if (id != media.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(media);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediaExists(media.ID))
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
            return View(media);
        }

        // GET: Media/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var media = await _context.Medias
                .SingleOrDefaultAsync(m => m.ID == id);
            if (media == null)
            {
                return NotFound();
            }

            return View(media);
        }

        // POST: Media/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var media = await _context.Medias.SingleOrDefaultAsync(m => m.ID == id);
            _context.Medias.Remove(media);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MediaExists(int id)
        {
            return _context.Medias.Any(e => e.ID == id);
        }

		public IActionResult UpdateRating()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateRating(int? newRating)
		{
			if (newRating != null)
			{
				ViewData["RowsAffected"] = await _context.Database.ExecuteSqlCommandAsync("UPDATE Medias SET Rating = {0}", parameters: newRating);
			}
			return View();
		}

		public IActionResult Import()
		{
			return View();
		}


}