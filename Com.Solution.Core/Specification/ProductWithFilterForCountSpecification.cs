using Com.Solution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Solution.Core.Specification
{
    public class ProductWithFilterForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFilterForCountSpecification(ProductSpecParams productSpecParams)
            : base(a => (string.IsNullOrEmpty(productSpecParams.Search) || a.Name.ToLower().Contains(productSpecParams.Search)) &&
                        (!productSpecParams.BrandId.HasValue || a.ProductBrandId == productSpecParams.BrandId) &&
                        (!productSpecParams.TypeId.HasValue || a.ProductTypeId == productSpecParams.TypeId))
        {

        }
    }
}
