using PersionalExpenditureManagement.PE.DbContext;
using PersionalExpenditureManagement.PE.DbContext.Infrastructure;
using PersionalExpenditureManagement.PE.DbContext.Models;
using PersionalExpenditureManagement.Service.Interface;
using PersionalExpenditureManagement.ViewModel;
using System.Linq.Expressions;

namespace PersionalExpenditureManagement.Service
{
    public class UserService : IUserService
    {
        protected readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserService> _logger;
        public UserService(IUnitOfWork unitOfWork, ILogger<UserService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public Task<CreateUserResult> CreateUserAsyns(CreateUserRequest createUserRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetListUser()
        {
            _logger.LogInformation("-- PROCESSING To Get " + nameof(UserService));
            return await _unitOfWork.GenericDB<User>().GetAll();
        }
    }
}
