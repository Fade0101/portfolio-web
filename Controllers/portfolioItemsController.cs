using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infrastructure;
using Web.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Core.Interfaces;

namespace Web.Controllers
{
    public class PortfolioItemsController : Controller
    {
        private readonly IUnitOfWork<portfolioItem> _portfolio;
        private  readonly IWebHostEnvironment _hosting;


        public PortfolioItemsController(IUnitOfWork<portfolioItem> portfolio, IWebHostEnvironment hosting)

        {
            _portfolio = portfolio;
            _hosting = hosting;
        }

        // GET: PortfolioItems
        public IActionResult Index()
        {
            return View(_portfolio.Entity.GetAll());
        }

        // GET: PortfolioItems/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolioItem = _portfolio.Entity.GetById(id);
            if (portfolioItem == null)
            {
                return NotFound();
            }

            return View(portfolioItem);
        }

        // GET: PortfolioItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PortfolioItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(portfolioViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.file != null)
                {
                    string uploads = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                    string fullPath = Path.Combine(uploads, model.file.FileName);
                    model.file.CopyTo(new FileStream(fullPath, FileMode.Create));
                }

                portfolioItem portfolioItem = new portfolioItem
                {
                    projectName = model.projectName,
                    description = model.description,
                    imageUrl = model.file.FileName
                };

                _portfolio.Entity.Insert(portfolioItem);
                _portfolio.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: PortfolioItems/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolioItem = _portfolio.Entity.GetById(id);
            if (portfolioItem == null)
            {
                return NotFound();
            }

            portfolioViewModel portfolioViewModel = new portfolioViewModel
            {
                id = portfolioItem.Id,
                description = portfolioItem.description,
                imageUrl = portfolioItem.imageUrl,
                projectName = portfolioItem.projectName
            };

            return View(portfolioViewModel);
        }

        // POST: PortfolioItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, portfolioViewModel model)
        {
            if (id != model.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (model.file != null)
                    {
                        string uploads = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                        string fullPath = Path.Combine(uploads, model.file.FileName);
                        model.file.CopyTo(new FileStream(fullPath, FileMode.Create));
                    }

                    portfolioItem portfolioItem = new portfolioItem
                    {
                        Id = model.id,
                        projectName = model.projectName,
                        description = model.description,
                        imageUrl = model.file.FileName
                    };

                    _portfolio.Entity.Update(portfolioItem);
                    _portfolio.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortfolioItemExists(model.id))
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
            return View(model);
        }

        // GET: PortfolioItems/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolioItem = _portfolio.Entity.GetById(id);
            if (portfolioItem == null)
            {
                return NotFound();
            }

            return View(portfolioItem);
        }

        // POST: PortfolioItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _portfolio.Entity.Delete(id);
            _portfolio.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool PortfolioItemExists(int id)
        {
            return _portfolio.Entity.GetAll().Any(e => e.Id == id);
        }
    }
}