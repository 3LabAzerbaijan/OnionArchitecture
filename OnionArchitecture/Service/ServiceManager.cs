using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service
{
    public sealed class ServiceManager(IRepositoryManager repositoryManager,
        ILoggerManager logger,
        IMapper mapper) : IServiceManager
    {
    }
}
