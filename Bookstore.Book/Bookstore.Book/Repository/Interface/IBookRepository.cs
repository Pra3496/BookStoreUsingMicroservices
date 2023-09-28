using Bookstore.Book.Model;

namespace Bookstore.Book.Repository.Interface
{
    public interface IBookRepository
    {
        Task<BookEntity> AddBook(AddBookModel model);
        Task<IEnumerable<BookEntity>> GetAllBooks();
        Task<BookEntity> GetBookById(long BookId);
        Task<bool> RemoveBook(long BookId);
        Task<bool> UpdateBook(long BookId, UpdateBookModel model);
    }
}
