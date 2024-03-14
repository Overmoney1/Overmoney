﻿using FluentValidation;
using MediatR;
using Overmoney.Api.DataAccess.Categories;
using Overmoney.Api.DataAccess.Payees;
using Overmoney.Api.DataAccess.Transactions;
using Overmoney.Api.DataAccess.Wallets;
using Overmoney.Api.Infrastructure.Exceptions;

namespace Overmoney.Api.Features.Transactions.Commands;

public sealed record UpdateTransactionCommand(
    int Id,
    int WalletId,
    int PayeeId,
    int CategoryId,
    DateTime TransactionDate,
    TransactionType TransactionType,
    string? Note,
    double Amount) : IRequest<TransactionEntity?>;

public sealed class UpdateTransactionCommandValidator : AbstractValidator<UpdateTransactionCommand>
{
    public UpdateTransactionCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);
        RuleFor(x => x.WalletId)
            .GreaterThan(0);
        RuleFor(x => x.PayeeId)
            .GreaterThan(0);
        RuleFor(x => x.CategoryId)
            .GreaterThan(0);
        RuleFor(x => x.TransactionType)
            .NotEmpty();
    }
}

public sealed class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, TransactionEntity?>
{
    private readonly IWalletRepository _walletRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IPayeeRepository _payeeRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMediator _mediator;

    public UpdateTransactionCommandHandler(IWalletRepository walletRepository, ICategoryRepository categoryRepository, IPayeeRepository payeeRepository, ITransactionRepository transactionRepository, IMediator mediator)
    {
        _walletRepository = walletRepository;
        _categoryRepository = categoryRepository;
        _payeeRepository = payeeRepository;
        _transactionRepository = transactionRepository;
        _mediator = mediator;
    }

    public async Task<TransactionEntity?> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = await _transactionRepository.GetAsync(request.Id, cancellationToken);

        if(transaction is null)
        {
            return await _mediator.Send(new CreateTransactionCommand(request.WalletId, request.PayeeId, request.CategoryId, request.TransactionDate, request.TransactionType, request.Note, request.Amount), cancellationToken);
        }

        var wallet = await _walletRepository.GetAsync(request.WalletId, cancellationToken);

        if (wallet is null)
        {
            throw new DomainValidationException($"Wallet of id {request.WalletId} does not exists.");
        }

        var category = await _categoryRepository.GetAsync(request.CategoryId, cancellationToken);

        if (category is null)
        {
            throw new DomainValidationException($"Category of id {request.CategoryId} does not exists.");
        }

        var payee = await _payeeRepository.GetAsync(request.PayeeId, cancellationToken);

        if (payee is null)
        {
            throw new DomainValidationException($"Payee of id {request.PayeeId} does not exists.");
        }

        await _transactionRepository.UpdateAsync(new(wallet.Id, request), cancellationToken);
        return null;
    }
}