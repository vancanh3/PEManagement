using PersionalExpenditureManagement.PE.DbContext.Models;
using PersionalExpenditureManagement.ViewModel;

namespace PersionalExpenditureManagement.Service.Interface
{
    public interface IUserService
    {
        Task<List<User>> GetListUser();
        Task<CreateUserResult> CreateUserAsyns(CreateUserRequest createUserRequest);
    }
}
