using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WOKtch.Models;

namespace WOKtch.repositories
{
    public class CartRepository
    {
        static Database1Entities db = new Database1Entities();

        /*================================Cart Repository========================================*/
            /*  Manipulate Cart Database  */
        public static int addProductToCart(Cart c)
        {
            db.Carts.Add(c);
            return db.SaveChanges();
        }
        public static int updateProductInCart(int id, Cart c)
        {
            Cart cart = db.Carts.Find(id);
            cart.ProductQuantity = c.ProductQuantity;
            return db.SaveChanges();
        }
        public static int deleteAllProductFromMemberCart(string email)
        {
            List<Cart> c = (from cart in db.Carts where cart.MemberEmail == email select cart).ToList();
            db.Carts.RemoveRange(c);
            return db.SaveChanges();
        }
        public static int deleteProductFromCartByCartId(int id)
        {
            List<Cart> c = (from cart in db.Carts where cart.CartId == id select cart).ToList();
            db.Carts.RemoveRange(c);
            return db.SaveChanges();
        }



            /*  GET Cart Data  */
        public static List<Cart> getCartProductByMember(string email)
        {
            return (from x in db.Carts where x.MemberEmail == email select x).ToList();
        }

        public static Cart getSpecificProductInCart(string email, int productId)
        {
            return (from x in db.Carts where x.MemberEmail == email && x.ProductId == productId select x).FirstOrDefault();
        }



        /*================================Custom Cart Repository========================================*/
        public static List<CartViewModel> getCartViewData(string email)
        {
            return (from c in db.Carts
                     join p in db.Products on c.ProductId equals p.ProductId
                     where c.MemberEmail == email
                     select new CartViewModel()
                     {
                         CartId = c.CartId,
                         productName = p.ProductName,
                         price = p.ProductPrice,
                         quantity = c.ProductQuantity,
                         subtotal = p.ProductPrice * c.ProductQuantity,
                         pictureUrl = p.ProductPicture                        
                    }).ToList();
                
        }
    }
}