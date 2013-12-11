using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventurousContacts.Models.Datamodels;

namespace AdventurousContacts.Models.Repository
{
    public interface IRepository : IDisposable
    {
        void Add(Contact contact);
        void DeleteContact(int contactId);
        IQueryable<Contact> FindAllContacts();
        Contact GetContactById(int contactId);
        List<Contact> GetLastContacts(int count = 20);
        void Save();
        void Update(Contact contact);
    }
}
