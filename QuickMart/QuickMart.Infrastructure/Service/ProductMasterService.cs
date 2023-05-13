using QuickMart.Core.Models;
using QuickMart.Core.Repository;
using QuickMart.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMart.Infrastructure.Service
{
    public class ProductMasterService : IProductMasterService
    {

        IProductMasterRepository _productMasterRepository; QuickMartDBContext _context;
        public ProductMasterService(IProductMasterRepository productMasterRepository, QuickMartDBContext context)
        {
            _productMasterRepository = productMasterRepository;
            _context = context;
        }
        public List<ProductMaster> GetProductList()
        {
            List<ProductMaster> productList;
            try
            {
                productList = _productMasterRepository.GetProductList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return productList;
        }
        public ResponseModel SaveProduct(ProductMaster productMaster)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                bool emailExist = _context.Products.Any(x => x.Name == productMaster.Name && x.ProductId != productMaster.ProductId);
                if (emailExist == true)
                {
                    model.IsSuccess = false;
                    model.Messsage = "Product name already exist.";
                    return model;
                }

                _productMasterRepository.SaveProduct(productMaster);
                _context.SaveChanges();
                model.IsSuccess = true;
                model.Messsage = "Success";
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.InnerException.Message;
            }
            return model;
        }

        public ProductMaster GetProductDetailsById(int prodId)
        {
            ProductMaster product = new ProductMaster();
            try
            {
                product = _productMasterRepository.GetProductDetailsById(prodId);

            }
            catch (Exception)
            {
                throw;
            }
            return product;
        }

        public ResponseModel DeleteProduct(int prodId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                if (prodId > 0)
                {
                    _productMasterRepository.DeleteProduct(prodId);
                    response.IsSuccess = true;
                    response.Messsage = "Product Deleted Successfully";

                }
                else
                {
                    response.IsSuccess = false;
                    response.Messsage = "Product Not Found";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Messsage = ex.Message;
            }
            return response;
        }
    }
}
