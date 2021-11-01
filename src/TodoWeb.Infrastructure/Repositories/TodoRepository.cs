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
        private readonly IMapper _mapper;
        private const string _mediaType = "application/json";

        public TodoRepository(IHttpClientFactory client, 
            IOptions<ApiRoutingConfiguration> routingConfiguration, IMapper mapper)
        {
            _client = client;
            _routingConfiguration = routingConfiguration.Value;
            _mapper = mapper;
        }

        public async Task<object> InsertAsync(TodoInputModel inputModel)
        {
            HttpRequestMessage request = new(HttpMethod.Post, $"{_routingConfiguration.GetTodosPath()}Create");
            request.Content = new StringContent(_mapper.Map<Todo>(inputModel).ToJson(), Encoding.UTF8, _mediaType);
            HttpResponseMessage response = await _client.CreateClient().SendAsync(request);

            if (response.StatusCode == HttpStatusCode.Created)
                return null;

            string json = await response.Content.ReadAsStringAsync();
            return json.FromJson<ErrorViewModel>();
        }

        public async Task<object> GetByIdAsync(int? id)
        {
            HttpRequestMessage request = new(HttpMethod.Get, $"{_routingConfiguration.GetTodosPath()}GetById/{id}");
            HttpResponseMessage response = await _client.CreateClient().SendAsync(request);

            string json = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == HttpStatusCode.OK)
                return json.FromJson<Todo>();

            return json.FromJson<ErrorViewModel>();
        }

        public async Task<object> GetAllAsync()
        {
            HttpRequestMessage request = new(HttpMethod.Get, $"{_routingConfiguration.GetTodosPath()}GetAll");
            HttpResponseMessage response = await _client.CreateClient().SendAsync(request);

            string json = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == HttpStatusCode.OK)
                return json.FromJson<IEnumerable<Todo>>();

            return json.FromJson<ErrorViewModel>();

        }

        public async Task<object> UpdateAsync(int? id, TodoInputModel inputModel)
        {
            HttpRequestMessage request = new(HttpMethod.Put, $"{_routingConfiguration.GetTodosPath()}Update/{id}");
            request.Content = new StringContent(inputModel.ToJson(), Encoding.UTF8, _mediaType);
            HttpResponseMessage response = await _client.CreateClient().SendAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return null;

            string json = await response.Content.ReadAsStringAsync();
            return json.FromJson<ErrorViewModel>();
        }

        public async Task<object> RemoveAsync(int? id)
        {
            HttpRequestMessage request = new(HttpMethod.Delete, $"{_routingConfiguration.GetTodosPath()}Remove/{id}");
            HttpResponseMessage response = await _client.CreateClient().SendAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return null;

            string json = await response.Content.ReadAsStringAsync();
            return json.FromJson<ErrorViewModel>();
        }
    }
}
