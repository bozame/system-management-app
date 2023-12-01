using enyoi_project.Mobile.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace enyoi_project.Mobile.Services
{
    public interface IApiServices
    {
        Task<Response> PostAsync<T>(string urlBase, string servicePrefix, string controller, T model);
    }
}
