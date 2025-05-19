using Fashion_Project.Contexts;
using Fashion_Project.Models;

namespace Fashion_Project.Services
{
    public class ProductService
    {
       private readonly FashionShopDBContext _shopDB;
        public ProductService()
        {
            _shopDB = new FashionShopDBContext();
        }

        #region CREATE 

        public void CreateProduct(Product product)
        {
            _shopDB.Products.Add(product);
            _shopDB.SaveChanges();
        }

        #endregion
        #region READ

        public List<Product> ReadProduct()
        {
            return _shopDB.Products.ToList();
        }
        public Product ReadProductById(int id)
        {
            Product? foundedProduct = _shopDB.Products.Find(id);
            if (foundedProduct is not null)
            {
                return foundedProduct;
            }
            else
            {
                throw new Exception("data not found");
            }
        }



        #endregion
        #region UPDATE

        public void UpdateProduct(int id,Product UpdatedProduct)
        {
            Product? clickedProduct = _shopDB.Products.Find(id);
            if (clickedProduct is not null)
            {
                clickedProduct.Name = UpdatedProduct.Name;
                clickedProduct.Description = UpdatedProduct.Description;
                clickedProduct.Price = UpdatedProduct.Price;
                _shopDB.SaveChanges();
            }
            else
            {
                throw new Exception("data not found");
            }

        }

        #endregion
        #region DELETE

        public void DeleteProduct(int id)
        {
            Product? clickedProduct = _shopDB.Products.Find(id);
            if (clickedProduct is not null)
            {
                _shopDB.Products.Remove(clickedProduct);
                _shopDB.SaveChanges();
            }
            
                
        }
        #endregion
    }
}
