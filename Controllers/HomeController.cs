    using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        
            private readonly IUnitOfWork<owner> _owner;
            private readonly IUnitOfWork<portfolioItem> _portfolio;

            public HomeController(
                IUnitOfWork<owner> owner,
                IUnitOfWork<portfolioItem> portfolio)
            {
                _owner = owner;
                _portfolio = portfolio;
            }
            public IActionResult Index()
            {
                var homeViewModel = new HomeViewModel
                {
                    owner = _owner.Entity.GetAll().First(),
                    PortfolioItems = _portfolio.Entity.GetAll().ToList()
                };

                return View(homeViewModel);
            }

            public IActionResult About()
            {
                return View();
            }

        }
    }
