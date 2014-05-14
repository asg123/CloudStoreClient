using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CloudStoreClient.Helper
{
    public class HttpClientHelper
    {
        private const string ResponseType = "application/json";

        public const string UserIdHeader = "CS-TokenAuth-UserId";
        public const string SecretHeader = "CS-TokenAuth-Secret";
        public const string OrganizationHeader = "CS-TokenAuth-OrganizationId";

        private readonly Guid _userId;
        private readonly  string _secret;
        private readonly Guid? _orgId;

        public HttpClientHelper(Guid userId, string secret)
            : this(userId, secret, null)
        {
        }

        public HttpClientHelper(Guid userId, string secret, Guid? orgId)
        {
            _userId = userId;
            _secret = secret;
            _orgId = orgId;
        }

        private HttpClient getClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ResponseType));
            client.DefaultRequestHeaders.Add(UserIdHeader,_userId.ToString());
            client.DefaultRequestHeaders.Add(SecretHeader,_secret);
            if (_orgId.HasValue)
                client.DefaultRequestHeaders.Add(OrganizationHeader, _orgId.Value.ToString());
            return client;
        }

        private void checkResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException(string.Format(
                    "StatusCode: {0}, Reason: {1}", response.StatusCode, response.ReasonPhrase));
        }

        public T DoGet<T>(Uri uriQuery)
        {
            using (var client = getClient())
            {
                var response = client.GetAsync(uriQuery).Result;
                checkResponse(response);
                return response.Content.ReadAsAsync<T>().Result;
            }

        }

        // http://stackoverflow.com/questions/15205389/get-response-from-postasjsonasync

        public HttpResponseMessage DoPost<TData>(Uri uriQuery, TData data) where TData : class
        {
            using (var client = getClient())
            {
                client.BaseAddress = uriQuery;
                var response = client.PostAsJsonAsync(string.Empty, data).Result;
                checkResponse(response);
                return response;

            }
        }

        public HttpResponseMessage DoPut<TData>(Uri uriQuery, TData data) where TData : class
        {
            using (var client = getClient())
            {
                client.BaseAddress = uriQuery;
                var response = client.PutAsJsonAsync(string.Empty, data).Result;
                checkResponse(response);
                return response;
            }
        }

        public HttpResponseMessage DoDelete(Uri uriQuery)
        {
            using (var client = getClient())
            {
                var response = client.DeleteAsync(uriQuery).Result;
                checkResponse(response);
                return response;
            }
        }
    }
}
