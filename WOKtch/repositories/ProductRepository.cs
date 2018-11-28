using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WOKtch.repositories
{
    public class ProductRepository
    {
        static Database1Entities db = new Database1Entities();

        /*================================Product Repository========================================*/
            /*  Manipulate Product Database  */
        public static int addProductToDatabase(Product p)
        {
            db.Products.Add(p);
            return db.SaveChanges();
        }
        public static int updateProductByIdToDatabase(int id, Product p)
        {
            Product currProduct = db.Products.Find(id);
            currProduct.ProductName = p.ProductName;
            currProduct.ProductPicture = p.ProductPicture;
            currProduct.ProductPrice = p.ProductPrice;
            currProduct.ProductStock = p.ProductStock;

            return db.SaveChanges();
        }
        public static int updateStockProduct(int productId, int quantity)
        {
            Product currProduct = db.Products.Find(productId);
            currProduct.ProductStock -= quantity;
            return db.SaveChanges();
        }
        public static int deleteProductByIdFromDatabase(int id)
        {
            Product p = db.Products.Find(id);
            db.Products.Remove(p);
            return db.SaveChanges();
        }
        


            /*  GET Product Data  */
        public static List<Product> getAllProductDetail()
        {
            return db.Products.ToList();
        }
        public static Product getProductById(int id)
        {
            return db.Products.Find(id);
        }        
    }
}