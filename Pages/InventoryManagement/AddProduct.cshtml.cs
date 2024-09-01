using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using myOnlineMart.Models;
using myOnlineMart.Services;

namespace myOnlineMart.Pages.InventoryManagement
{
    public class AddProductModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly mySmartMartDbContext context;

        [BindProperty]
        public ProductDto ProductDto { get; set; } = new ProductDto();  
        public AddProductModel(IWebHostEnvironment environment, mySmartMartDbContext context)
        {
            this.environment = environment;
            this.context = context;




        }

        public void OnGet()
        {

        }
        public string erroMessage = "";
        public string successMessage = "";

        public void OnPost() 
        { 
            if(ProductDto.ImageFile == null)
            {
                ModelState.AddModelError("ProductDto.ImageFile", "The image file is required");
            }
            if (!ModelState.IsValid)
            {
                erroMessage = "Please Provide all required fields";
                return;
            }

            //save img
            string newFileName= DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(ProductDto.ImageFile!.FileName);
            string imagePath =environment.WebRootPath + "/ProductsImg" +newFileName;
            using (var stream = System.IO.File.Create(imagePath))
            { 
                ProductDto.ImageFile.CopyTo(stream);
            };

            //save product to db
            Product product = new Product()
            {
                Name = ProductDto.Name,
                Category = ProductDto.Category,
                Price = ProductDto.Price,
                Description = ProductDto.Description ?? "",
                ImageFileName = newFileName,
                CreatedAt = DateTime.Now,

            };
            context.Products.Add(product);
            context.SaveChanges();

            // clear form
            ProductDto.Name = "";
            ProductDto.Category = "";
            ProductDto.Price = 0m ;
            ProductDto.Description = "";
            ProductDto.ImageFile = null;

            ModelState.Clear();

            successMessage = "Product added succesfully";
            Response.Redirect("ProductList");








        }


    }

}

