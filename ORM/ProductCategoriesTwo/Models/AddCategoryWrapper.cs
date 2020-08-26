using System.Collections.Generic;

namespace ProductCategoriesTwo.Models
{
    public class AddCategoryWrapper
    {
        public Category CatForm {get; set; }

        public List<Category> AllCategories {get; set; }

    }
}