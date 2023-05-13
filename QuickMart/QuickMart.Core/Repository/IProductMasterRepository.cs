﻿using QuickMart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMart.Core.Repository
{
    public interface IProductMasterRepository
    {
        void SaveProduct(ProductMaster productMaster);

        List<ProductMaster> GetProductList();
        ProductMaster GetProductDetailsById(int prodId);

        void DeleteProduct(int prodId);
    }
}