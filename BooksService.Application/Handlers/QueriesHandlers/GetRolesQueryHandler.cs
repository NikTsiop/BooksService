using BooksService.Application.DTO;
using BooksService.Application.Interfaces.Repositories;
using BooksService.Application.Mapper;
using BooksService.Application.Queries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BooksService.Application.Handlers.QueriesHandlers
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, List<RoleDTO>>
    {
        private readonly ILogger<GetRolesQueryHandler> _logger;
        private readonly IRoleRepository _roleRepository;

        public GetRolesQueryHandler(IRoleRepository roleRepository, ILogger<GetRolesQueryHandler> logger)
        {
            _logger = logger;
            _roleRepository = roleRepository;
        }

        public async Task<List<RoleDTO>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling GetRolesQuery");

            var roles = await _roleRepository.GetAllAsync();

            return CreateMapper.Mapper.Map<List<RoleDTO>>(roles);
        }
    }
}
