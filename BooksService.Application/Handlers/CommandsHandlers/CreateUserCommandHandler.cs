using BooksService.Application.Commnands;
using BooksService.Application.DTO;
using BooksService.Application.Interfaces.DecorateInterfaces;
using BooksService.Application.Interfaces.Repositories;
using BooksService.Application.Mapper;
using BooksService.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using static BooksService.Domain.Exceptions.UserExceptions;

namespace BooksService.Application.Handlers.CommandsHandlers;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDTO>
{
    private readonly IUserRepository _userRepository;
    private readonly IAddRepository<User> _addRepository;
    private readonly ILogger<CreateUserCommandHandler> _logger;

    public CreateUserCommandHandler(
        IUserRepository userRepository,
        IAddRepository<User> addRepository,
        ILogger<CreateUserCommandHandler> logger)
    {
        _userRepository = userRepository;
        _addRepository = addRepository;
        _logger = logger;
    }

    public async Task<UserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling CreateUserCommand for Surname: {Surname}", request.Surname);

        var user = CreateMapper.Mapper.Map<User>(request);

        if (await _userRepository.GetByUserInfo(user) is not null)
            throw new DuplicateUserException();

        var result = await _addRepository.AddAsync(user);

        return new UserDTO { Id = result };
    }
}
