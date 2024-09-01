using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using myOnlineMart.Models;
using myOnlineMart.Services;

namespace myOnlineMart.Pages.InventoryManagement
{
    public class EditProductModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly mySmartMartDbContext context;

        [BindProperty]
        public ProductDto ProductDto {  get; set; } = new ProductDto();
        public Product Product { get; set; } = new Product();

        public string erroMessage = "";
        public string successMessage = "";
        public EditProductModel(IWebHostEnvironment environment, mySmartMartDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }

        public void OnGet(int? id)
        {
            if(id == null)
            {
                Response.Redirect("to product list");
                return;
            }
            var product = context.Products.Find(id);

            if (product == null) 
            {
                Response.Redirect("to product list");
                return;
            
            }

            ProductDto.Name = product.Name;
            ProductDto.Category = product.Category;
            ProductDto.Price = product.Price;
            ProductDto.Description = product.Description;


            Product = product;
        }

        public void OnPost(int? id) {

            if (id == null)
            {
                Response.Redirect("productlist");
            }
            if (!ModelState.IsValid)
            {
                erroMessage = "Please Provide all required fields";
                return;
            }
            var product = context.Products.Find(id);
            if (product == null)
            {
                Response.Redirect("productlist");
            }



            //update img
            string newFileName = product.ImageFileName;
            if(ProductDto.ImageFile!= null)
            {
                 newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(ProductDto.ImageFile!.FileName);
                string imagePath = environment.WebRootPath + "/ProductsImg" + newFileName;

                using (var stream = System.IO.File.Create(imagePath))
                {
                    ProductDto.ImageFile.CopyTo(stream);
                };
                string oldImagePath = environment.WebRootPath + "/ProductsImg" + newFileName;
                System.IO.File.Delete(oldImagePath);


            }

            //UPATE product to db

           Product.Name= ProductDto.Name;
            Product.Category = ProductDto.Category;
            Product.Price = ProductDto.Price;
            Product.Description = ProductDto.Description;
            Product.ImageFileName = newFileName;

           
          
            context.SaveChanges();

           
            ModelState.Clear();

            successMessage = "Product added succesfully";
            Response.Redirect("ProductList");









        }
    }
}
