using BookStore.Order.Repository.Model;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BookStore.Order.Repository.Service
{
    public class BookService
    {


        public async Task<BookEntity>GetBookByIdFromApi(long bookId)
        {

            if(bookId == null)
            {
                return null;
            }

            BookEntity book = new BookEntity(); 

            string url = "https://localhost:7049/api/Book/bookById";

            string bookIduri = bookId.ToString();
            

            var fullUrl = $"{url}?bookId={Uri.EscapeDataString(bookIduri)}";


            HttpClient client = new();

            HttpResponseMessage responceFromApi = await client.GetAsync(fullUrl);

            if(responceFromApi.IsSuccessStatusCode)
            {
                string content = await responceFromApi.Content.ReadAsStringAsync(); 

                ResponseEntity response = JsonConvert.DeserializeObject<ResponseEntity>(content);

                if(response.isSuccess)
                {
                    string bookContent = JsonConvert.SerializeObject(response.data);

                    book = JsonConvert.DeserializeObject<BookEntity>(bookContent);


                }

                return book;
            }

            return null;

        }




    }
}
