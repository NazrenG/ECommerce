using ECommerce.Business.Abstraction;
using ECommerce.Entity.Concretes;
using ECommerce.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class CartService : ICartService
    {
        public void AddList(Product product, Cart cart)
        {
           CartLine cartLine= cart.Lines.FirstOrDefault(c=>c.Product.ProductId==product.ProductId);

            if (cartLine != null)
            {
                cartLine.Quantity++;
            }
            else
            {
                cart.Lines.Add(new CartLine { Product = product, Quantity = 1 });
            } 
        }

        public void Decrement(int productId, Cart cart)
        {
            CartLine cartLine = cart.Lines.FirstOrDefault(c => c.Product.ProductId == productId);
            if (cartLine != null)
            {
                if (cartLine.Quantity >1) { 
                    cartLine.Quantity--;
                }
            }
        }

        public void DeleteList(int productId, Cart cart)
        {
            CartLine cartLine = cart.Lines.FirstOrDefault(c=>c.Product.ProductId == productId);
           
                cart.Lines.Remove(cartLine);
           
            
        }

        public List<CartLine> GetList(Cart cart)
        {
            return cart.Lines;
        }

        public void Increment(int productId, Cart cart)
        {
            CartLine cartLine = cart.Lines.FirstOrDefault(c => c.Product.ProductId == productId);
            if (cartLine != null)
            {
                 
                    cartLine.Quantity++;
                
            }
        }
    }
}
