using Bookstore.Book.Model;
using Bookstore.Book.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Bookstore.Book.Repository.Service
{
    public class BookRepository : IBookRepository
    {
        private readonly IConfiguration Iconfiguration;

        private readonly ContextDB contextDB;

        public BookRepository(IConfiguration Iconfiguration, ContextDB contextDB)
        {
            this.Iconfiguration = Iconfiguration;
            this.contextDB = contextDB;
        }

        /// <summary>
        /// This Method is Used to Add Book information in Database.
        /// </summary>
        /// <param name="model">This Model has all parameter needed to Add book in Database.</param>
        /// <returns>Book Entity that is Added.</returns>
        public async Task<BookEntity> AddBook(AddBookModel model)
        {
            try
            {
                BookEntity bookEntity = new BookEntity();

                bookEntity.BookName = model.BookName;

                bookEntity.Author = model.Author;

                bookEntity.Discription = model.Discription;

                bookEntity.Price = model.Price;

                bookEntity.DiscountPrice = model.DiscountPrice;

                bookEntity.AvalableQuantity = model.AvalableQuantity;

                bookEntity.Quantity = model.Quantity;

                bookEntity.Image = model.Image;


                await contextDB.Books.AddAsync(bookEntity);

                await contextDB.SaveChangesAsync();


                if (bookEntity != null)
                {
                    return bookEntity;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// This Method is Used to Retrive All Books that is Present in Database.
        /// </summary>
        /// <returns>List of Book</returns>
        public async Task<IEnumerable<BookEntity>> GetAllBooks()
        {

            try
            {
                var books = await contextDB.Books.ToListAsync();


                if (books != null)
                {
                    return books;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);    
            }


        }

        /// <summary>
        /// The Method is used to Retrive a specific book.
        /// </summary>
        /// <param name="BookId">It is used to verify the book in database.</param>
        /// <returns>Specific book from Database</returns>
        public async Task<BookEntity> GetBookById(long BookId)
        {

            try
            {
                var book = await contextDB.Books.FirstOrDefaultAsync(x => x.BookId == BookId);

                if (book != null)
                {
                    return book;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> RemoveBook(long BookId)
        {
            try
            {
                var book = await contextDB.Books.FirstOrDefaultAsync(x => x.BookId == BookId);

                if (book != null)
                {
                    contextDB.Books.Remove(book);
                    await contextDB.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateBook(long BookId, UpdateBookModel model)
        {
            try
            {
                var bookEntity = await contextDB.Books.FirstOrDefaultAsync(x => x.BookId == BookId);

                if (bookEntity != null)
                {
                    bookEntity.BookName = model.BookName;

                    bookEntity.Author = model.Author;

                    bookEntity.Discription = model.Discription;

                    bookEntity.Price = model.Price;

                    bookEntity.DiscountPrice = model.DiscountPrice;

                    bookEntity.AvalableQuantity = model.AvalableQuantity;

                    bookEntity.Quantity = model.Quantity;

                    bookEntity.Image = model.Image;


                    contextDB.Books.Update(bookEntity);

                    await contextDB.SaveChangesAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




       









    }
}
