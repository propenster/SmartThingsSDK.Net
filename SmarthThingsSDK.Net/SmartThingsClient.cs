using System;
using System.Net.Http;
using SmarthThingsSDK.Net.Endpoints;
using SmarthThingsSDK.Net.Interfaces;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using static SmarthThingsSDK.Net.Models.Error;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using SmarthThingsSDK.Net.Models;

namespace SmarthThingsSDK.Net
{
    public class SmartThingsClient : ISmartThingsClient, IDisposable
    {
        private static string _apiKey;
        private static string _version;
        private static string _smartThingsBaseUrl;
        private static string _smarthThingsAuthUrl;
        private readonly HttpClient _client;

        public SmartThingsClient(string apiKey, string version)
        {
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            _version = version ?? "v1";

            Locations = new LocationEndpoint(this);
            var clientHandler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
                {
                    return true;
                },               
               
            };
            _client = new HttpClient(clientHandler);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                | SecurityProtocolType.Tls11
                | SecurityProtocolType.Tls12;
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));           
            _smartThingsBaseUrl = $"https://api.smartthings.com/{_version}/";
            _smarthThingsAuthUrl = "https://auth-global.api.smartthings.com";
            _client.BaseAddress = new Uri(_smartThingsBaseUrl);

        }

        internal async Task<SmartThingsResponse<T>> GetAsync<T>(string apiRelativeUrl) where T : IEntity, new()
        {
            //T result = new();
            //var errorResponse = new ErrorResponse();
            //T successResponse = new T();

            try
            {
                var apiUrl = $"{_smartThingsBaseUrl}{apiRelativeUrl}";
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, apiUrl);
                requestMessage.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
                //take this as a placeholder for authorization/
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
                var response = await _client.SendAsync(requestMessage);
                var stringResult = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    //result = new ErrorResponse();
                    var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(stringResult);
                    //throw new HttpResponseException(requestMessage.CreateErrorResponse(HttpStatusCode.NotFound, String.Format("Contact {0} not found.", id)));
                    //throw new Exception(errorResponse);

                    return new SmartThingsResponse<T>(errorResponse);

                    //return (T)Convert.ChangeType(errorResponse, typeof(T));
                }

                var successResponse = JsonConvert.DeserializeObject<T>(stringResult);

                //if (!response.IsSuccessStatusCode)
                //{
                //    result = new ErrorResponse();
                //    result =(object) JsonConvert.DeserializeObject<ErrorResponse>(stringResult);
                //}
                //else
                //    var result = JsonConvert.DeserializeObject<IEntity>(stringResult);

                //return result;
                return new SmartThingsResponse<T>(successResponse);

                //return (T)Convert.ChangeType(successResponse, typeof(T));


            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    RequestId = Guid.NewGuid().ToString(),
                    Error = new ErrorObject
                    {
                        Code = "99",
                        Message = ex.Message
                    }
                };
                return new SmartThingsResponse<T>(errorResponse);
            }
            finally
            {
                Dispose();
            }



        }
        internal async Task<SmartThingsResponse<T>> PostAsync<T>(string apiRelativeUrl, object requestObject) where T : IEntity, new()
        {
            //T result = new();
            //var errorResponse = new ErrorResponse();
            //T successResponse = new T();

            try
            {
                var apiUrl = $"{_smartThingsBaseUrl}{apiRelativeUrl}";
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, apiUrl);
                requestMessage.Content = new StringContent(JsonConvert.SerializeObject(requestObject), Encoding.UTF8, "application/json");
                //take this as a placeholder for authorization/
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
                var response = await _client.SendAsync(requestMessage);
                var stringResult = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    //result = new ErrorResponse();
                    var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(stringResult);
                    //throw new HttpResponseException(requestMessage.CreateErrorResponse(HttpStatusCode.NotFound, String.Format("Contact {0} not found.", id)));
                    //throw new Exception(errorResponse);

                    return new SmartThingsResponse<T>(errorResponse);

                    //return (T)Convert.ChangeType(errorResponse, typeof(T));
                }

                var successResponse = JsonConvert.DeserializeObject<T>(stringResult);

                //if (!response.IsSuccessStatusCode)
                //{
                //    result = new ErrorResponse();
                //    result =(object) JsonConvert.DeserializeObject<ErrorResponse>(stringResult);
                //}
                //else
                //    var result = JsonConvert.DeserializeObject<IEntity>(stringResult);

                //return result;
                return new SmartThingsResponse<T>(successResponse);

                //return (T)Convert.ChangeType(successResponse, typeof(T));


            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    RequestId = Guid.NewGuid().ToString(),
                    Error = new ErrorObject
                    {
                        Code = "99",
                        Message = ex.Message
                    }
                };
                return new SmartThingsResponse<T>(errorResponse);
            }
            finally
            {
                Dispose();
            }



        }
        internal async Task<SmartThingsResponse<T>> PutAsync<T>(string apiRelativeUrl, object requestObject) where T : IEntity, new()
        {
            //T result = new();
            //var errorResponse = new ErrorResponse();
            //T successResponse = new T();

            try
            {
                var apiUrl = $"{_smartThingsBaseUrl}{apiRelativeUrl}";
                var requestMessage = new HttpRequestMessage(HttpMethod.Put, apiUrl);
                requestMessage.Content = new StringContent(JsonConvert.SerializeObject(requestObject), Encoding.UTF8, "application/json");
                //take this as a placeholder for authorization/
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
                var response = await _client.SendAsync(requestMessage);
                var stringResult = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    //result = new ErrorResponse();
                    var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(stringResult);
                    //throw new HttpResponseException(requestMessage.CreateErrorResponse(HttpStatusCode.NotFound, String.Format("Contact {0} not found.", id)));
                    //throw new Exception(errorResponse);

                    return new SmartThingsResponse<T>(errorResponse);

                    //return (T)Convert.ChangeType(errorResponse, typeof(T));
                }

                var successResponse = JsonConvert.DeserializeObject<T>(stringResult);

                //if (!response.IsSuccessStatusCode)
                //{
                //    result = new ErrorResponse();
                //    result =(object) JsonConvert.DeserializeObject<ErrorResponse>(stringResult);
                //}
                //else
                //    var result = JsonConvert.DeserializeObject<IEntity>(stringResult);

                //return result;
                return new SmartThingsResponse<T>(successResponse);

                //return (T)Convert.ChangeType(successResponse, typeof(T));


            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    RequestId = Guid.NewGuid().ToString(),
                    Error = new ErrorObject
                    {
                        Code = "99",
                        Message = ex.Message
                    }
                };
                return new SmartThingsResponse<T>(errorResponse);
            }
            finally
            {
                Dispose();
            }



        }
        internal async Task<SmartThingsResponse<T>> DeleteAsync<T>(string apiRelativeUrl) where T : IEntity, new()
        {
            //T result = new();
            //var errorResponse = new ErrorResponse();
            //T successResponse = new T();

            try
            {
                var apiUrl = $"{_smartThingsBaseUrl}{apiRelativeUrl}";
                var requestMessage = new HttpRequestMessage(HttpMethod.Delete, apiUrl);
                requestMessage.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
                //take this as a placeholder for authorization/
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
                var response = await _client.SendAsync(requestMessage);
                var stringResult = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    //result = new ErrorResponse();
                    var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(stringResult);
                    //throw new HttpResponseException(requestMessage.CreateErrorResponse(HttpStatusCode.NotFound, String.Format("Contact {0} not found.", id)));
                    //throw new Exception(errorResponse);

                    return new SmartThingsResponse<T>(errorResponse);

                    //return (T)Convert.ChangeType(errorResponse, typeof(T));
                }

                var successResponse = JsonConvert.DeserializeObject<T>(stringResult);

                //if (!response.IsSuccessStatusCode)
                //{
                //    result = new ErrorResponse();
                //    result =(object) JsonConvert.DeserializeObject<ErrorResponse>(stringResult);
                //}
                //else
                //    var result = JsonConvert.DeserializeObject<IEntity>(stringResult);

                //return result;
                return new SmartThingsResponse<T>(successResponse);

                //return (T)Convert.ChangeType(successResponse, typeof(T));


            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    RequestId = Guid.NewGuid().ToString(),
                    Error = new ErrorObject
                    {
                        Code = "99",
                        Message = ex.Message
                    }
                };
                return new SmartThingsResponse<T>(errorResponse);
            }
            finally
            {
                Dispose();
            }



        }


        public void Dispose()
        {
            _client.Dispose();
        }

        public ILocation Locations { get; }

    }
}

