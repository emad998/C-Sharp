using System.Collections.Generic;

namespace ProductCategoriesTwo.Models
{
    public class AddCategoryToProductWrapper
    {
        public Product ToDisplay {get; set; }

        public List<Product> AllProducts {get; set; }
        public Association AssociationForm {get; set; }
        public List<Association> AllAssociations {get; set; }

        public List<Category> CatDropdown {get; set; }
    }
}