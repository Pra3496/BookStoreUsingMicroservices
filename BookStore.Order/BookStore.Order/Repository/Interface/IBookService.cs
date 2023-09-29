namespace BookStore.Order.Repository.Interface
{
    public interface IBookService
    {
        Task<BookEntity> GetBookByIdFromApi(long bookId);
    }
}
