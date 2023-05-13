using QuickMart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMart.Core.Service
{
    public interface IProductMasterService
    {
        ResponseModel SaveProduct(ProductMaster productMaster);

        List<ProductMaster> GetProductList();
        ProductMaster GetProductDetailsById(int prodId);

        ResponseModel DeleteProduct(int prodId);
    }
}
