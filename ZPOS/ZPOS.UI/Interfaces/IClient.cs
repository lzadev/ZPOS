using System.Collections.Generic;
using ZPOS.UI.Entities;

namespace ZPOS.UI.Interfaces
{
    public interface IClient
    {
        IEnumerable<Client> GetClients();

        Client GetClientById(int id);

        bool AddClient(Client client);

        bool DeleteClient(Client client);

        bool UpdateClient(Client client);

        bool Exists(string document);
    }
}
