using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace ProductCategoriesTwo.Models
{
    
    public class AddProductWrapper
    {
        
        public Product ProdForm {get; set; }

        public List<Product> AllProducts {get; set; }
    }
}