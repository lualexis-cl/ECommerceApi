using Com.Solution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Solution.Core.Specification
{
    public class ProductWithDetailSpecification : BaseSpecification<Product>
    {
        public ProductWithDetailSpecification()
        {
            AddInclude(a => a.ProductType);
            AddInclude(a => a.ProductBrand);
        }

        public ProductWithDetailSpecification(int id)
            : base(a => a.Id == id)
        {
            AddInclude(a => a.ProductType);
            AddInclude(a => a.ProductBrand);
        }
    }
}
