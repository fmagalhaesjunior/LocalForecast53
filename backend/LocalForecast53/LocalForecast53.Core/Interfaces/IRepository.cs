using LocalForecast53.Core.Entities;

namespace LocalForecast53.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity? GetById(object id);
        TEntity? GetByField(string field, object value);
        void Remove(object id);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        void UpdateFields(object id, Dictionary<string, object> fields);
    }
}
