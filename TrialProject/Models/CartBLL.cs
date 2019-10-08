using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrialProjectEntities;

namespace TrialProject.Models
{
    public class CartBLL
    {

        PracticeContext db = new PracticeContext();



        Cart c1 = new Cart();



        public bool AddCart(Cart model)
        {
            var availableStock = db.Products.Where(x => x.PId == model.PId).FirstOrDefault();
            int StockInHand = model.Quantity;
            if (StockInHand >= model.Quantity)
            {



                var Authorize = db.Carts.Where(x =>x.PId== model.PId && x.UId == model.UId).FirstOrDefault();
                if (Authorize == null)
                {
                   
                    Product product = db.Products.Find(model.PId);
                    int total = product.Quantity * product.PPrice;
                    Cart cart = new Cart();
                    cart.PId = model.PId;
                    cart.Item = product.PImage;
                    cart.Description = product.PName;
                    cart.Quantity = product.Quantity;
                    cart.Price = product.PPrice;
                    cart.UId = model.UId;
                    cart.Total = total;
                    db.Carts.Add(cart);
                    db.SaveChanges();
                    return true;




                }
                else
                {
                    db.Carts.Add(model);
                    db.SaveChanges();
                    Authorize.Quantity = Authorize.Quantity + model.Quantity;
                    Authorize.Total = Authorize.Total + (model.Quantity * Authorize.Price);
                    db.SaveChanges();
                    return true;

                }
                
                   
               
            }
            else
            {
                
                return false;
            }
        }



        public bool RemoveFromCart(Cart model)
        {
            var Authorize = db.Carts.Where(x => x.PId == model.PId && x.UId == model.UId).FirstOrDefault();
            if (Authorize.Quantity == 1)
            {
                db.Entry(Authorize).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
                return true;
            }



            else if (Authorize.Quantity > 1)
            {
                Authorize.Quantity = Authorize.Quantity - model.Quantity;
                Authorize.Total = Authorize.Total - (model.Quantity * Authorize.Price);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }




        public IEnumerable<Cart> GetCartValue(Cart model)
        {
            var query = from c in db.Carts where c.UId == model.UId select c;
            return query;
        }
    }


}

