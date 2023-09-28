using Bookstore.Book.Model;
using Bookstore.Book.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        private ResponceModel response;
        public BookController(IBookRepository repository)
        {
            this.bookRepository = repository;
            this.response = new ResponceModel();
        }

        /// <summary>
        /// This Method is used to Add Book.
        /// </summary>
        /// <param name="model">This Model has All Parameters Needed to Add Book.</param>
        /// <returns>Responce Model That has responce Parameter along with book object.</returns>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        [Route("book")]
        public async Task<ResponceModel> AddBook(AddBookModel model)
        {
            try
            {
                var result = await bookRepository.AddBook(model);

                if (result != null)
                {
                    response.Data = result;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Book Added Unsuccessfully";
                }
                return response;
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }



        /// <summary>
        /// This Method is used to Retrive All Books.
        /// </summary>
        /// <returns>List of books</returns>
        [HttpGet]
        [Route("book")]
        public async Task<ResponceModel> GetAllBooks()
        {
            try
            {
                var result = await bookRepository.GetAllBooks();

                if (result != null)
                {
                    response.Data = result;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Retrive AllBooks Unsuccessful";
                }

                return response;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// This Method used to Retrive Specific book.
        /// </summary>
        /// <param name="BookId">It is used to verify the book.</param>
        /// <returns>A Specific book.</returns>
        /// <exception cref="Exception"></exception>
        [HttpGet]
        [Route("bookById")]
        public async Task<ResponceModel> GetBookById(long BookId)
        {
            try
            {
                var result = await bookRepository.GetBookById(BookId);

                if (result != null)
                {
                    response.Data = result;

                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Retrive Book Unsuccessful";
                }
                return response;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
