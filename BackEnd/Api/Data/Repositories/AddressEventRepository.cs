using Api.Data.Interfaces;
using Api.Models;
using System.Linq;

namespace Api.Data.Repositories
{
    public class AddressEventRepository : IAddressEventRepository
    {
        private readonly DataContext _context;
        public AddressEventRepository(DataContext context) 
        {
            _context = context;
        }
        public void Delete(int iD)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AddressEvent> GetAll()
        {
            return _context.AddressEvents.ToList();
        }

        public AddressEvent GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(AddressEvent model)
        {
            throw new NotImplementedException();
        }

        public void Update(AddressEvent model)
        {
            throw new NotImplementedException();
        }
    }
}
