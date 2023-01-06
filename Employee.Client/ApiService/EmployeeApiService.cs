using Employee.Client.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Client.ApiService
{
    public class EmployeeApiService : IEmployeeApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmployeeApiService(IHttpClientFactory httpClientFactory , IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserInfoViewModel> GetUserInfo()
        {
            var idpClient = _httpClientFactory.CreateClient("IDPClient");

            var metaDataResponse = await idpClient.GetDiscoveryDocumentAsync();
            if (metaDataResponse.IsError)
            {
                throw new HttpRequestException("Something went wrong when getting token"); 
            }

            var accessToken = await _httpContextAccessor
                .HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

            var userInfoResponse = await idpClient.GetUserInfoAsync(
                new UserInfoRequest
                {
                    Address = metaDataResponse.UserInfoEndpoint,
                    Token = accessToken
                });

            if (userInfoResponse.IsError)
            {
                throw new HttpRequestException("Something went wrong when getting token");
            }

            var userInfoDictionary = new Dictionary<string, string>();

            foreach(var claim in userInfoResponse.Claims)
            {
                userInfoDictionary.Add(claim.Type, claim.Value);
            }

            return new UserInfoViewModel(userInfoDictionary);
        }

        public async Task<IEnumerable<EmployeeClientModel>> GetEmployees()
        {

            // WAY 1 . second method to consume protected API using IHttpClientFactory

            var httpClient = _httpClientFactory.CreateClient("EmployeeAPIClient");

            //var request = new HttpRequestMessage(
            //    HttpMethod.Get,
            //    "/api/employees/");

            var request = new HttpRequestMessage(
                HttpMethod.Get,
                "/employees");

            var response = await httpClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var employeeList = JsonConvert.DeserializeObject<List<EmployeeClientModel>>(content);
            return employeeList;



            // 1 -Get Token From identity server, of course we should provide the IS configurations
            // 2 - Send Reqquest to protected API adding received access token from the identity server to this request
            // 3 -  Deserialize object to Employeelist 

            // 1i  .....
            //var apiClientCredentials = new ClientCredentialsTokenRequest
            //{
            //    Address = "https://localhost:5005/connect/token",

            //    ClientId = "employerClient",
            //    ClientSecret = "secret",

            //    //This is the scope of the protected API
            //    Scope = "employerAPI"
            //};

            //// creates a new HttpClient to talk to our IdentityServer (localhost:5005)
            //var client = new HttpClient();

            ////To check if we can reach the Discovery Document
            //var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5005");
            //if (disco.IsError)
            //{
            //    return null; // throw 500 error
            //}


            //// 1ii. Authenticate and get an access token from the identity server
            //var tokenResponse = await client.RequestClientCredentialsTokenAsync(apiClientCredentials);
            //if (tokenResponse.IsError)
            //{
            //    return null;
            //}



            //// 2. Send Reqquest to protected API 

            ////Another HttpClient for talking now with our protected API
            //var apiClient = new HttpClient();

            ////Set the access_token in the request Authorization: Bearer <token>
            //apiClient.SetBearerToken(tokenResponse.AccessToken);

            ////Send a request to our protected API
            //var response = await apiClient.GetAsync("https://localhost:5001/api/employees");
            //response.EnsureSuccessStatusCode();

            //var content = await response.Content.ReadAsStringAsync();


            ////Deserialize Object to employeeList
            //List<EmployeeClientModel> employees = JsonConvert.DeserializeObject<List<EmployeeClientModel>>(content);
            //return employees;
        }

        public async Task<EmployeeClientModel> CreateEmployee(EmployeeClientModel employeeClientModel)
        {
            var httpClient = _httpClientFactory.CreateClient("EmployeeAPIClient");

            var request = new HttpRequestMessage(
                HttpMethod.Post,
                "/employees");

            var content1 = new StringContent(JsonConvert.SerializeObject(employeeClientModel), Encoding.UTF8, "application/json");
            request.Content = content1;

            var response = await httpClient.SendAsync(
               request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var employeePost = JsonConvert.DeserializeObject<EmployeeClientModel>(content);
            return employeePost;
        }

        public Task DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeClientModel> GetEmployee(string id)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeClientModel> GetEmployee(int id)
        {
            throw new NotImplementedException();
        }  

        public Task<EmployeeClientModel> UpdateEmployee(EmployeeClientModel employeeClientModel)
        {
            throw new NotImplementedException();
        }

        
    }
}
