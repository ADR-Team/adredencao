
namespace Api.Data.Interfaces
{
    public interface Default
    {
        IEnumerable<T> Get();
        T GetByID(int studentId);
        void Insert(T model);
        void Delete(int modelID);
        void Update(T model);
    }
}
