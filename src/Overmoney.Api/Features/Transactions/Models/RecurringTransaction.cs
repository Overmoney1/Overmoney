﻿using Overmoney.Api.Features.Categories.Models;
using Overmoney.Api.Features.Payees.Models;
using Overmoney.Api.Features.Wallets.Models;

namespace Overmoney.Api.Features.Transactions.Models;

public class RecurringTransaction
{
    public long Id { get; }
    public int UserId { get; }
    public Wallet Wallet { get; }
    public Payee Payee { get; }
    public Category Category { get; }
    public DateTime TransactionDate { get; }
    public TransactionType TransactionType { get; }
    public string? Note { get; }
    public double Amount { get; }
    public string Schedule { get; }
    public DateTime NextOccurrence { get; }


    public RecurringTransaction(
        long id,
        int userId,
        Wallet wallet,
        Payee payee,
        Category category,
        DateTime transactionDate,
        TransactionType transactionType,
        string? note,
        double amount,
        string schedule,
        DateTime nextOccurrence)
    {
        Id = id;
        UserId = userId;
        Wallet = wallet;
        Payee = payee;
        Category = category;
        TransactionDate = transactionDate;
        TransactionType = transactionType;
        Note = note;
        Amount = amount;
        Schedule = schedule;
        NextOccurrence = nextOccurrence;
    }

    public RecurringTransaction(
        int userId,
        Wallet wallet,
        Payee payee,
        Category category,
        DateTime transactionDate,
        TransactionType transactionType,
        string? note,
        double amount,
        string schedule,
        DateTime nextOccurrence)
    {
        UserId = userId;
        Wallet = wallet;
        Payee = payee;
        Category = category;
        TransactionDate = transactionDate;
        TransactionType = transactionType;
        Note = note;
        Amount = amount;
        Schedule = schedule;
        NextOccurrence = nextOccurrence;
    }
}
