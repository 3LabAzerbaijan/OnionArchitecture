using Contracts;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {

        private readonly RepositoryContext _repositoryContext;
       

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();

    }
}
