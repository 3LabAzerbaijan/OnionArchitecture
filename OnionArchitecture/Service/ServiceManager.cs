using AutoMapper;
using Contracts;
using Entities.ConfigurationModels;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Service.Contracts;

namespace Service
{
    public sealed class ServiceManager(IRepositoryManager repositoryManager,
        ILoggerManager logger,
        IMapper mapper,
        UserManager<User> userManager,
        IConfiguration configuration,
        IOptions<JwtConfiguration> options,
        SignInManager<User> signInManager) : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _authenticationService = new Lazy<IAuthenticationService>(
               () => new AuthenticationService(logger, mapper, userManager, signInManager, configuration));

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
