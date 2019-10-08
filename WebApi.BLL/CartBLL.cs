using System;
using System.Collections.Generic;
using System.Linq;

using TrialProject;

namespace WebApi.BLL
{
    public class CartBLL
    {
        PracticeContext db = new PracticeContext();



        Cart c1 = new Cart();



        public Boolean AddCart(Cart model)
        {



            var availableStock = db.Products.Where(x => x.Product_Id == model.Product_Id).FirstOrDefault();
            int StockInHand = availableStock.Product_Quantity;
            if (StockInHand > model.Quantity)
            {



                var Authorize = db.carts.Where(x => x.Product_Id == model.Product_Id && x.userId == model.userId).FirstOrDefault();
                if (Authorize == null)
                {
                    db.carts.Add(model);
                    db.SaveChanges();
                    var query = db.carts.Where(x => x.Cart_Id == model.Cart_Id).FirstOrDefault();
                    var query1 = db.Products.Where(p => p.Product_Id == model.Product_Id).FirstOrDefault();
                    double price = query1.Product_Price;
                    query.Price = price;
                    query.Total = (query.Quantity * price);
                    db.SaveChanges();
                    return true;




                }
                else
                {
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
            var Authorize = db.carts.Where(x => x.Product_Id == model.Product_Id && x.userId == model.userId).FirstOrDefault();
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
            var query = from c in db.carts where c.userId == model.userId select c;
            return query;
        }
    }
}