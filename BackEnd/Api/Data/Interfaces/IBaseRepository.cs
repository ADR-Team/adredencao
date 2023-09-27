using System.Collections.Generic;
namespace Api.Data.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        void Insert(T model);
        void Delete(int iD);
        void Update(T model);
    }
}
