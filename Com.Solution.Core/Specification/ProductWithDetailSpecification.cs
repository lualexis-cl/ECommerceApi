using Com.Solution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Solution.Core.Specification
{
    public class ProductWithDetailSpecification : BaseSpecification<Product>
    {
        public ProductWithDetailSpecification(ProductSpecParams productSpecParams)
            : base(a => (string.IsNullOrEmpty(productSpecParams.Search) || a.Name.ToLower().Contains(productSpecParams.Search)) &&
                        (!productSpecParams.BrandId.HasValue || a.ProductBrandId == productSpecParams.BrandId) &&
                        (!productSpecParams.TypeId.HasValue || a.ProductTypeId == productSpecParams.TypeId))
        {
            AddInclude(a => a.ProductType);
            AddInclude(a => a.ProductBrand);
            AddOrderBy(a => a.Name);
            ApplyPaging(productSpecParams.PageSize * (productSpecParams.PageIndex - 1),
                productSpecParams.PageSize);

            if (!string.IsNullOrEmpty(productSpecParams.Sort))
            {
                switch (productSpecParams.Sort)
                {
                    case "priceAsc":
                        {
                            AddOrderBy(a => a.Price);
                            break;
                        }
                    case "priceDesc":
                        {
                            AddOrderByDescending(a => a.Price);
                            break;
                        }
                    default:
                        {
                            AddOrderBy(a => a.Name);
                            break;
                        }
                }
            }
        }

        public ProductWithDetailSpecification(int id)
            : base(a => a.Id == id)
        {
            AddInclude(a => a.ProductType);
            AddInclude(a => a.ProductBrand);
        }
    }
}
