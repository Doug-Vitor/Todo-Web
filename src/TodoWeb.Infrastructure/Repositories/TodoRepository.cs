using AutoMapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TodoWeb.Domain.Entities;
using TodoWeb.Domain.Repositories;
using TodoWeb.Domain.ViewModels;
using TodoWeb.Domain.ViewModels.TodoViewModels;
using TodoWeb.Domain.Configurations;
using TodoWeb.Infrastructure.Extensions;

namespace TodoWeb.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly IHttpClientFactory _client;
        private readonly ApiRoutingConfiguration _routingConfiguration;
        private const string _mediaType = "application/json";

        public TodoRepository(IHttpClientFactory client, 
            IOptions<ApiRoutingConfiguration> routingConfiguration)
        {
            _client = client;
            _routingConfiguration = routingConfiguration.Value;
        }

        public async Task<object> InsertAsync(TodoInputModel inputModel)
        {
            HttpRequestMessage request = new(HttpMethod.Post, $"{_routingConfiguration.GetTodosPath()}Create");
            request.Content = new StringContent(inputModel.ToJson(), Encoding.UTF8, _mediaType);
            HttpResponseMessage response = await _client.CreateClient().SendAsync(request);

            return response.StatusCode == HttpStatusCode.Created ? null 
                : await response.Content.ReadAsStringAsync().Result.FromJsonAsync<ErrorViewModel>();
        }

        public async Task<object> GetByIdAsync(int? id)
        {
            HttpRequestMessage request = new(HttpMethod.Get, $"{_routingConfiguration.GetTodosPath()}GetById/{id.GetValueOrDefault()}");
            HttpResponseMessage response = await _client.CreateClient().SendAsync(request);

            string json = await response.Content.ReadAsStringAsync();
            return response.StatusCode is HttpStatusCode.OK ?
                json.FromJson<Todo>() : json.FromJson<ErrorViewModel>();
        }

        public async Task<object> GetAllAsync()
        {
            HttpRequestMessage request = new(HttpMethod.Get, $"{_routingConfiguration.GetTodosPath()}GetAll");
            HttpResponseMessage response = await _client.CreateClient().SendAsync(request);

            string json = await response.Content.ReadAsStringAsync();
            return response.StatusCode == HttpStatusCode.OK ? 
                json.FromJson<IEnumerable<Todo>>() : json.FromJson<ErrorViewModel>();

        }

        public async Task<object> UpdateAsync(int? id, TodoInputModel inputModel)
        {
            HttpRequestMessage request = new(HttpMethod.Patch, $"{_routingConfiguration.GetTodosPath()}Update/{id.GetValueOrDefault()}");
            request.Content = new StringContent(inputModel.ToJson(), Encoding.UTF8, _mediaType);
            HttpResponseMessage response = await _client.CreateClient().SendAsync(request);

            return response.StatusCode is HttpStatusCode.OK ? null
                : await response.Content.ReadAsStringAsync().Result.FromJsonAsync<ErrorViewModel>();
        }

        public async Task<object> RemoveAsync(int? id)
        {
            HttpRequestMessage request = new(HttpMethod.Delete, $"{_routingConfiguration.GetTodosPath()}Remove/{id.GetValueOrDefault()}");
            HttpResponseMessage response = await _client.CreateClient().SendAsync(request);

            return response.StatusCode is HttpStatusCode.OK ? null
                : await response.Content.ReadAsStringAsync().Result.FromJsonAsync<ErrorViewModel>();
        }
    }
}
