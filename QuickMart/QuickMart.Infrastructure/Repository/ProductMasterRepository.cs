using QuickMart.Core.Models;
using QuickMart.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMart.Infrastructure.Repository
{
    public class ProductMasterRepository : IProductMasterRepository
    {
        QuickMartDBContext _context;

        public ProductMasterRepository(QuickMartDBContext context)
        {
            _context = context;
        }

        public List<ProductMaster> GetProductList()
        {
            return _context.Set<ProductMaster>().ToList();
        }
        public void SaveProduct(ProductMaster PoductMaster)
        {
            if (PoductMaster.ProductId > 0)
            {
                _context.Products.Update(PoductMaster);
            }
            else
            {
                _context.Products.Add(PoductMaster);
            }

        }
        public ProductMaster GetProductDetailsById(int prodId)
        {
            return _context.Products.Find(prodId);
        }

        public void DeleteProduct(int prodId)
        {
            var empData = _context.Products.FirstOrDefault(x => x.ProductId == prodId);
            _context.Remove(empData);
            _context.SaveChanges();
        }
    }
}
