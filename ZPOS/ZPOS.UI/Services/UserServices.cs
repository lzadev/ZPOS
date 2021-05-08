using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZPOS.UI.Interfaces;
using ZPOS.UI.Models;

namespace ZPOS.UI.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUser _userRepository;

        public UserServices(IUser userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }
        public async Task<IEnumerable<UserVM>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }
    }
}
