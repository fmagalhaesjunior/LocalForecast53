using AutoMapper;
using FluentValidation;
using LocalForecast53.Core.Entities;
using LocalForecast53.Core.Interfaces;

namespace LocalForecast53.Core.Services
{
    public class DomainService<TEntity> : IService<TEntity> where TEntity : BaseEntity
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public DomainService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Add<TInputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TValidator : AbstractValidator<TEntity>
        {
            TEntity entity = _mapper.Map<TEntity>(inputModel);
            Validate(entity, Activator.CreateInstance<TValidator>());
            _repository.Add(entity);
        }

        public void Delete(object id) => _repository.Remove(id);

        public TOutputModel GetByField<TOutputModel>(string field, object value) where TOutputModel : class
        {
            var entity = _repository.GetByField(field, value);
            var outputModel = _mapper.Map<TOutputModel>(entity);

            return outputModel;
        }

        public TOutputModel GetById<TOutputModel>(object id) where TOutputModel : class
        {
            var entity = _repository.GetById(id);
            var outputModel = _mapper.Map<TOutputModel>(entity);

            return outputModel;
        }

        public IEnumerable<TOutputModel> GetAll<TOutputModel>() where TOutputModel : class
        {
            var entity = _repository.GetAll();
            var outputModel = _mapper.Map<IEnumerable<TOutputModel>>(entity);
            return outputModel;
        }

        public TOutputModel Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<TEntity>
        {
            TEntity entity = _mapper.Map<TEntity>(inputModel);
            Validate(entity, Activator.CreateInstance<TValidator>());
            _repository.Update(entity);
            TOutputModel outputModel = _mapper.Map<TOutputModel>(entity);

            return outputModel;
        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Records not detected");

            validator.ValidateAndThrow(obj);
        }
    }
}
