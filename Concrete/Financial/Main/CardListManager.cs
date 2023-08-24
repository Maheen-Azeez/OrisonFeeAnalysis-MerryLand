using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using OrisonFeeAnalysis.Contract.Financial.Main;

using OrisonFeeAnalysis.Entities.Financial.Main;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Concrete.Financial.Main
{
    public class CardListManager : ICardList
    {

        private string BaseUrl;
        private readonly IConfiguration _config;
        private readonly HttpClient httpClient;

        public CardListManager(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }
        public async Task<IEnumerable<Cards>> GetCards()
        {
            return await httpClient.GetJsonAsync<Cards[]>(BaseUrl + "CardsList");
        }
    }
}
