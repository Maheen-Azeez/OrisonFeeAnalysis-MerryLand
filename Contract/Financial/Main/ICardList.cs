using OrisonFeeAnalysis.Entities.Financial.Main;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Contract.Financial.Main
{
    public interface ICardList
    {
        public Task<IEnumerable<Cards>> GetCards();
    }
}
