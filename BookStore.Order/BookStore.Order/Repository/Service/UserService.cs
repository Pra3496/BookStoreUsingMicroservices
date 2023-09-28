using Newtonsoft.Json;

namespace BookStore.Order.Repository.Service
{
    public class UserService
    {
        public async Task<UserEntity> GetUserByIdFromApi(long userId)
        {

            if (userId == null)
            {
                return null;
            }

            UserEntity user = new UserEntity();

            string url = "https://localhost:7207/api/User/user";

            string userIduri = userId.ToString();


            var fullUrl = $"{url}?userId={Uri.EscapeDataString(userIduri)}";

            HttpClient client = new();

            HttpResponseMessage responceFromApi = await client.GetAsync(fullUrl);

            if (responceFromApi.IsSuccessStatusCode)
            {
                string content = await responceFromApi.Content.ReadAsStringAsync();

                ResponseUserEntity response = JsonConvert.DeserializeObject<ResponseUserEntity>(content);

                if (response.isSuccess)
                {
                    string userContent = JsonConvert.SerializeObject(response.data);

                    user = JsonConvert.DeserializeObject<UserEntity>(userContent);


                }

                return user;
            }

            return null;

        }
    }
}
