using Examples.Charge.Application.Common.Messages;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonFacade
    { 
        Task<PersonResponse> FindAllAsync();
        Task<BaseResponse> GetAsync(int id);
    }
}