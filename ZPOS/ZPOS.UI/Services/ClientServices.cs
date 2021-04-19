namespace ZPOS.UI.Services
{
    using System;
    using System.Collections.Generic;
    using ZPOS.UI.Entities;
    using ZPOS.UI.Interfaces;
    public class ClientServices : IClientServices
    {
        private readonly IClient _clientRepository;

        public ClientServices(IClient clientRepository)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        }
        public bool AddClient(Client client)
        {
            return _clientRepository.AddClient(client);
        }

        public bool DeleteClient(Client client)
        {
            return _clientRepository.DeleteClient(client);
        }

        public Client GetClientById(int id)
        {
            return _clientRepository.GetClientById(id);
        }

        public IEnumerable<Client> GetClients()
        {
            return _clientRepository.GetClients();
        }

        public bool UpdateClient(Client client)
        {
            return _clientRepository.UpdateClient(client);
        }
    }
}
