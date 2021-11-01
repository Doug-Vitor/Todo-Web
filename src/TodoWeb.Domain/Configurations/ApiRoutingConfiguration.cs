using System;

namespace TodoWeb.Domain.Configurations
{
    public class ApiRoutingConfiguration
    {
        public Uri BasePath { get; set; }
        public Uri TodosPath { get; set; }

        public Uri GetTodosPath() => new(string.Concat(BasePath, TodosPath));
    }
}
