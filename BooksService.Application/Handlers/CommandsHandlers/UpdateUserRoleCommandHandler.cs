using BooksService.Application.Commnands;
using BooksService.Application.Interfaces.DecorateInterfaces;
using BooksService.Application.Interfaces.Repositories;
using BooksService.Domain.Entities;
using MediatR;
using static BooksService.Domain.Exceptions.UserExceptions;

namespace BooksService.Application.Handlers.CommandsHandlers
{
    public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommand>
    {

        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUpdateRepository<User> _updateRepository;

        public UpdateUserRoleCommandHandler(
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IUpdateRepository<User> updateRepository
        )
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _updateRepository = updateRepository;
        }

        public async Task Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId)
                   ?? throw new UserNotFoundException();

            var roles = await _roleRepository.GetByIdsAsync(request.RoleIds);

            if (roles.Count != request.RoleIds.Count)
                throw new ArgumentException("One or more roles were not found");

            user.UpdateRoles(roles);
            await _updateRepository.UpdateAsync(user);
        }
    }
}
