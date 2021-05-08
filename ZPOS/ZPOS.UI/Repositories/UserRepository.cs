using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ZPOS.UI.Context;
using ZPOS.UI.Interfaces;
using ZPOS.UI.Models;


namespace ZPOS.UI.Repositories
{
    public class UserRepository : IUser
    {
        private readonly ZposContext _context;

        public UserRepository(ZposContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<UserVM>> GetUsers()
        {
            using var command = _context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "sp_GetUsers";
            command.CommandType = CommandType.StoredProcedure;

            await _context.Database.OpenConnectionAsync();

            var dataReader = await command.ExecuteReaderAsync();

            var usersToReturn = new List<UserVM>();

            if (dataReader.HasRows)
            {
                while (await dataReader.ReadAsync())
                {
                    usersToReturn.Add(new UserVM
                    {
                        Id = dataReader[0].ToString(),
                        UserName = dataReader[1].ToString(),
                        CompletedName = $"{dataReader[2]} {dataReader[3]}",
                        Status = (bool)dataReader[4],
                        Role = dataReader[5].ToString()
                    });
                }
            }
            await dataReader.CloseAsync();

            return usersToReturn;
        }
    }
}
