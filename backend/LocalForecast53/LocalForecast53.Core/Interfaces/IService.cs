using FluentValidation;
using LocalForecast53.Core.Entities;

namespace LocalForecast53.Core.Interfaces
{
    public interface IService<TEntity> where TEntity : BaseEntity
    {
        void Add<TInputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class;

        void Delete(object id);
        TOutputModel GetById<TOutputModel>(object id)
            where TOutputModel : class;
        IEnumerable<TOutputModel> GetAll<TOutputModel>()
            where TOutputModel : class;
        TOutputModel GetByField<TOutputModel>(string field, object value)
            where TOutputModel : class;
        TOutputModel Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class;
    }
}
