using BooksService.Application.Commnands;
using BooksService.Application.Interfaces;
using BooksService.Application.Mapper;
using BooksService.Domain.Entities;
using MediatR;
using static BooksService.Domain.Exceptions.UserExceptions;

namespace BooksService.Application.Handlers.CommandsHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = CreateMapper.Mapper.Map<User>(request);

            if (await _userRepository.GetByUserInfo(user) is not null)
                throw new DuplicateUserException();

            var result = await _userRepository.AddAsync(user);

            return result;
        }
    }
}
