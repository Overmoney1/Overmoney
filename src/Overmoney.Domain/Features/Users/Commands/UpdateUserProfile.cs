using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Overmoney.Domain.DataAccess;
using Overmoney.Domain.Exceptions;
using Overmoney.Domain.Features.Users.Models;

namespace Overmoney.Domain.Features.Users.Commands;

public sealed record UpdateUserProfileCommand(UserProfileId Id, string? Email) : IRequest<UserProfile>
{ }

internal sealed class UpdateUserProfileCommandValidator : AbstractValidator<UpdateUserProfileCommand>
{
    public UpdateUserProfileCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Id.Value)
            .NotEmpty();

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
    }
}

internal sealed class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, UserProfile>
{
    private readonly IUserProfileRepository _userRepository;
    private readonly ILogger<UpdateUserProfileCommandHandler> _logger;

    public UpdateUserProfileCommandHandler(IUserProfileRepository userRepository, ILogger<UpdateUserProfileCommandHandler> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task<UserProfile> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id!, cancellationToken);

        if (user is null)
        {
            throw new DomainValidationException("Cannot update account!");
        }

        var userToUpdate = new UserProfile(user!.Id!, request.Email!);

        await _userRepository.UpdateAsync(userToUpdate, cancellationToken);

        _logger.LogInformation("Account (ID: {Id}) email was changed to {Email}", request.Id.Value, request.Email);

        return userToUpdate;
    }
}
