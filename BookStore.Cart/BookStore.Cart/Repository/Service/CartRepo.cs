using BookStore.Cart.Model;
using BookStore.Cart.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Cart.Repository.Service
{
    public class CartRepo : ICartRepo
    {
        private readonly ContextDB context;
        public CartRepo(ContextDB context) 
        {
            this.context = context;
        }
        public async Task<CartEntity> AddToCart(CartModel model)
        {
            try
            {
                CartEntity cartEntity = new CartEntity();

                cartEntity.BookId = model.BookId;
                cartEntity.UserId = model.UserId;
                cartEntity.Qty = model.Qty;
                cartEntity.IsPurchesed = false;

                if(cartEntity != null)
                {
                    await context.Carts.AddAsync(cartEntity);

                    await context.SaveChangesAsync();
                    
                }

                return cartEntity;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);    
            }
        }

        public async Task<bool> DeleteById(long CartId)
        {
            try
            {
                var result = context.Carts.FirstOrDefault(x=> x.CartId == CartId);

                if (result != null)
                {
                    context.Carts.Remove(result);

                    await context.SaveChangesAsync();

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<CartEntity>> GetAllCart(long userId)
        {
            try
            {
                

                List<CartEntity> result = await context.Carts.Where(x=> x.UserId == userId).ToListAsync();

                if(result != null)
                {
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<CartEntity>> GetAllCartWhichOrder(long userId)
        {
            try
            {


                List<CartEntity> result = await context.Carts.Where(x => x.UserId == userId && x.IsPurchesed == false).ToListAsync();

                if (result != null)
                {
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateAllCartWhichOrdered(long userId)
        {
            try
            {
                List<CartEntity> CartOrders = await context.Carts.Where(x => x.UserId == userId).ToListAsync();

                if (CartOrders != null)
                {
                    foreach (CartEntity cart in CartOrders)
                    {
                        cart.IsPurchesed = true;
                        context.Carts.Update(cart);
                        await context.SaveChangesAsync();
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
