using BookStore.Order.Repository.Interface;
using BookStore.Order.Repository.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace BookStore.Order.Repository.Service
{
    public class BookService : IBookService
    {

        private readonly HttpClient _httpMessingClient;
        public BookService(IHttpClientFactory httpClientFactory)
        {
            _httpMessingClient = httpClientFactory.CreateClient("BookApi");//A method CreateClient which return the http client Object
        }


        /// <summary>
        /// This Method is Used to Retrive Book information from User Api using HttpClient.
        /// </summary>
        /// <param name="bookId">Its is used to pass as parameter in URL</param>
        /// <returns>Object of BookEntity</returns>
        public async Task<BookEntity>GetBookByIdFromApi(long bookId)
        {
            try
            {
                if (bookId == null)
                {
                    return null;
                }

                BookEntity bookEntity = new BookEntity();
                //IHttpFactory
                HttpResponseMessage responseMessage = await _httpMessingClient.GetAsync($"?bookId={bookId}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    string content = await responseMessage.Content.ReadAsStringAsync();

                    ResponceModel response = JsonConvert.DeserializeObject<ResponceModel>(content);

                    if (response.IsSuccess)
                    {
                        bookEntity = JsonConvert.DeserializeObject<BookEntity>(response.Data.ToString());
                    }
                }
                return bookEntity;


            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }

           

        }




    }
}
