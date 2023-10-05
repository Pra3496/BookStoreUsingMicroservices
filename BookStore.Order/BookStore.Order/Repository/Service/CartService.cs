using BookStore.Order.Repository.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using BookStore.Order.Repository.Interface;

namespace BookStore.Order.Repository.Service
{
    public class CartService : ICartService
    {
        private readonly HttpClient _httpMessingClient;
        public CartService(IHttpClientFactory httpClientFactory)
        {
            _httpMessingClient = httpClientFactory.CreateClient("CartApi");  //A method CreateClient which return the http client Object
        }


        public async Task<List<CartEntity>> GetCartFromApi(string Token)
        {
            try
            {
                if (Token == null)
                {
                    return null;
                }

                string result = Token.Replace("Bearer", "").Trim();


                List<CartEntity> cartList = new();

                _httpMessingClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result);//Defult Request Header Modify Every  subSequent Request of httpClient Request.
                HttpResponseMessage responseMessage = await _httpMessingClient.GetAsync("orders");



                if (responseMessage.IsSuccessStatusCode)
                {
                    string content = await responseMessage.Content.ReadAsStringAsync();
                    ResponseModelCart responseEntity = JsonConvert.DeserializeObject<ResponseModelCart>(content);



                    // if (responseEntity.IsSuccess)
                    //{
                    //      userEntity = JsonConvert.DeserializeObject<>(responseEntity.Data.ToString());
                    //}
                    cartList =  responseEntity.data;
                }

                return cartList;
                


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public async Task<bool> UpdateCartFromApi(string Token)
        {
            try
            {
                if (Token == null)
                {
                    return false;
                }

                string result = Token.Replace("Bearer", "").Trim();


                List<CartEntity> cartList = new();

                _httpMessingClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result);//Defult Request Header Modify Every  subSequent Request of httpClient Request.
                HttpResponseMessage responseMessage = await _httpMessingClient.PatchAsync("",null);



                if (responseMessage.IsSuccessStatusCode)
                {
                    string content = await responseMessage.Content.ReadAsStringAsync();

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
