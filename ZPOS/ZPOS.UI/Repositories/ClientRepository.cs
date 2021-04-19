namespace ZPOS.UI.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ZPOS.UI.Context;
    using ZPOS.UI.Entities;
    using ZPOS.UI.Interfaces;
    public class ClientRepository : IClient
    {
        private readonly ZposContext _context;

        public ClientRepository(ZposContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool AddClient(Client client)
        {
            _context.Clients.Add(client);

            return Save();
        }

        public bool DeleteClient(Client client)
        {
            _context.Clients.Remove(client);

            return Save();
        }

        public Client GetClientById(int id)
        {
            return _context.Clients.FirstOrDefault(c => c.ID == id);
        }

        public IEnumerable<Client> GetClients()
        {
            return _context.Clients.Where(c=> c.Deleted == false);
        }

        public bool UpdateClient(Client client)
        {
            _context.Clients.Update(client);

            return Save();
        }

        private bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
