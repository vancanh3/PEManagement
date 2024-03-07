using PersionalExpenditureManagement.PE.DbContext;
using PersionalExpenditureManagement.PE.DbContext.Infrastructure;
using PersionalExpenditureManagement.PE.DbContext.Models;
using PersionalExpenditureManagement.Service.Interface;
using PersionalExpenditureManagement.ViewModel;

namespace PersionalExpenditureManagement.Service
{
    public class UserService : IUserService
    {
        protected readonly IUnitOfWork _unitOfWork;
        private readonly GenericRepository<User> _userRepository;

        public UserService(IUnitOfWork unitOfWork, GenericRepository<User> userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }
        public Task<CreateUserResult> CreateUserAsyns(CreateUserRequest createUserRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetListUser()
        {
            return await _userRepository.GetAll();
        }
    }
}
