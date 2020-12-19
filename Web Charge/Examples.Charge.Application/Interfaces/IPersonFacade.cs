using Examples.Charge.Application.Common.Messages;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonFacade
    { 
        Task<PersonResponse> FindAllAsync();
        Task<PersonResponse> GetAsync(int id);
        Task<BaseResponse> PostAsync(PersonRequest request);
        Task<PersonResponse> PutAsync(int id, PersonRequest request);
        Task<PhoneNumberTypeResponse> GetPhoneNumberTypes();
    }
}    