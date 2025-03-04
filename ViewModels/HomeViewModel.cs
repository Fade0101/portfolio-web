using Core.Entities;

namespace Web.ViewModels
{
    public class HomeViewModel
    {
        public owner owner {  get; set; }
        public List <portfolioItem> PortfolioItems { get; set; }

    }
}
