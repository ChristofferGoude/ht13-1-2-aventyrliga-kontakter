using AdventurousContacts.Models.Datamodels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AdventurousContacts.Models.Repository
{
    public class Repository : IRepository
    {
        private bool _disposed = false;

        private AdventurousContactsEntities _entities = new AdventurousContactsEntities();

        public IQueryable<Contact> FindAllContacts()
        {
            return _entities.Contacts.AsQueryable();
        }

        public Contact GetContactById(int contactId)
        {
            return _entities.Contacts.Find(contactId);
        }

        public List<Contact> GetLastContacts(int count = 20)
        {
            return _entities.Contacts.OrderByDescending(c => c.ContactID)
                .Take(count).ToList();
        }

        public void Add(Contact contact)
        {
            _entities.Contacts.Add(contact);
        }

        public void DeleteContact(int contactId)
        {
            var match = _entities.Contacts.Find(contactId);
            _entities.Contacts.Remove(match);
        }

        public void Update(Contact contact)
        {
            _entities.Entry(contact).State = EntityState.Modified;  
        }

        public void Save()
        {
            _entities.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _entities.Dispose();
                }
            }
            _disposed = true;
        }
    }
}