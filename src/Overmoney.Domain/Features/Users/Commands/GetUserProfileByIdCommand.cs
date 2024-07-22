using FluentValidation;
using MediatR;
using Overmoney.Domain.DataAccess;
using Overmoney.Domain.Features.Users.Models;

namespace Overmoney.Domain.Features.Users.Commands;
public sealed record GetUserProfileByIdCommand(UserProfileId? Id) : IRequest<UserProfile?> { }

internal sealed class GetUserProfileByIdCommandValidator : AbstractValidator<GetUserProfileByIdCommand>
{
    public GetUserProfileByIdCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
        RuleFor(x => x.Id!.Value)
            .NotEmpty();
    }
}

internal sealed class GetUserProfileByIdCommandHandler : IRequestHandler<GetUserProfileByIdCommand, UserProfile?>
{
    private readonly IUserProfileRepository _userRepository;

    public GetUserProfileByIdCommandHandler(IUserProfileRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserProfile?> Handle(GetUserProfileByIdCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id!, cancellationToken);

        if (user is null)
        {
            return null;
        }

        return user;
    }
}
