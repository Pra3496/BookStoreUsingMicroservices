using BookStore.Order.Repository.Interface;
using BookStore.Order.Repository.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http.Headers;

namespace BookStore.Order.Repository.Service
{
    public class UserService : IUserService
    {

        private readonly HttpClient httpClient;
        public UserService(IHttpClientFactory httpClientFactory) 
        {
            httpClient = httpClientFactory.CreateClient("UserApi");
        }

        /// <summary>
        /// This Method is Used to Retrive User information from User Api using HttpClient.
        /// </summary>
        /// <param name="userId">Its is used to pass as parameter in URL</param>
        /// <returns>Object of User Entity</returns>
        /// <exception cref="Exception"></exception>
        public async Task<UserEntity> GetUserByIdFromApi(long userId)
        {

            try
            {
                UserEntity userEntity = null;

               
                HttpResponseMessage responseMessage = await httpClient.GetAsync($"?userId={userId}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    string content = await responseMessage.Content.ReadAsStringAsync();
                    ResponceModel responseEntity = JsonConvert.DeserializeObject<ResponceModel>(content);

                    if (responseEntity.IsSuccess)
                    {
                        userEntity = JsonConvert.DeserializeObject<UserEntity>(responseEntity.Data.ToString());
                    }
                }
                return userEntity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
