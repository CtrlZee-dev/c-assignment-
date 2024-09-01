using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using myOnlineMart.Models;
using myOnlineMart.Services;

namespace myOnlineMart.Pages.InventoryManagement
{
    public class IndexModel : PageModel
    {
        public List<Product> Products { get; set; } = new List<Product>();
        private readonly mySmartMartDbContext context;

        public IndexModel(mySmartMartDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            Products = context.Products.OrderByDescending(p => p.Id).ToList();
        }
    }
}
