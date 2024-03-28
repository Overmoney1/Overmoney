﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Overmoney.Api.DataAccess;

#nullable disable

namespace Overmoney.Api.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("overmoney_api")
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Overmoney.Api.DataAccess.Budgets.BudgetEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Month")
                        .HasColumnType("integer")
                        .HasColumnName("month");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<int>("Year")
                        .HasColumnType("integer")
                        .HasColumnName("year");

                    b.HasKey("Id")
                        .HasName("pk_budgets");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_budgets_user_id");

                    b.ToTable("budgets", "overmoney_api");
                });

            modelBuilder.Entity("Overmoney.Api.DataAccess.Budgets.BudgetLineEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("double precision")
                        .HasColumnName("amount");

                    b.Property<int>("BudgetId")
                        .HasColumnType("integer")
                        .HasColumnName("budget_id");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    b.HasKey("Id")
                        .HasName("pk_budget_lines");

                    b.HasIndex("BudgetId")
                        .HasDatabaseName("ix_budget_lines_budget_id");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_budget_lines_category_id");

                    b.ToTable("budget_lines", "overmoney_api");
                });

            modelBuilder.Entity("Overmoney.Api.DataAccess.Categories.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_categories");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_categories_user_id");

                    b.ToTable("categories", "overmoney_api");
                });

            modelBuilder.Entity("Overmoney.Api.DataAccess.Currencies.CurrencyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_currencies");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasDatabaseName("IX_Code");

                    b.ToTable("currencies", "overmoney_api");
                });

            modelBuilder.Entity("Overmoney.Api.DataAccess.Payees.PayeeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_payees");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_payees_user_id");

                    b.ToTable("payees", "overmoney_api");
                });

            modelBuilder.Entity("Overmoney.Api.DataAccess.Transactions.AttachmentEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("file_path");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<long>("TransactionId")
                        .HasColumnType("bigint")
                        .HasColumnName("transaction_id");

                    b.HasKey("Id")
                        .HasName("pk_attachments");

                    b.HasIndex("TransactionId")
                        .HasDatabaseName("ix_attachments_transaction_id");

                    b.ToTable("attachments", "overmoney_api");
                });

            modelBuilder.Entity("Overmoney.Api.DataAccess.Transactions.RecurringTransactionEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("double precision")
                        .HasColumnName("amount");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    b.Property<DateTime>("NextOccurrence")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("next_occurrence");

                    b.Property<string>("Note")
                        .HasColumnType("text")
                        .HasColumnName("note");

                    b.Property<int>("PayeeId")
                        .HasColumnType("integer")
                        .HasColumnName("payee_id");

                    b.Property<string>("Schedule")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("schedule");

                    b.Property<int>("TransactionType")
                        .HasColumnType("integer")
                        .HasColumnName("transaction_type");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<int>("WalletId")
                        .HasColumnType("integer")
                        .HasColumnName("wallet_id");

                    b.HasKey("Id")
                        .HasName("pk_recurring_transactions");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_recurring_transactions_category_id");

                    b.HasIndex("PayeeId")
                        .HasDatabaseName("ix_recurring_transactions_payee_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_recurring_transactions_user_id");

                    b.HasIndex("WalletId")
                        .HasDatabaseName("ix_recurring_transactions_wallet_id");

                    b.ToTable("recurring_transactions", "overmoney_api");
                });

            modelBuilder.Entity("Overmoney.Api.DataAccess.Transactions.TransactionEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("double precision")
                        .HasColumnName("amount");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    b.Property<string>("Note")
                        .HasColumnType("text")
                        .HasColumnName("note");

                    b.Property<int>("PayeeId")
                        .HasColumnType("integer")
                        .HasColumnName("payee_id");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("transaction_date");

                    b.Property<int>("TransactionType")
                        .HasColumnType("integer")
                        .HasColumnName("transaction_type");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<int>("WalletId")
                        .HasColumnType("integer")
                        .HasColumnName("wallet_id");

                    b.HasKey("Id")
                        .HasName("pk_transactions");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_transactions_category_id");

                    b.HasIndex("PayeeId")
                        .HasDatabaseName("ix_transactions_payee_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_transactions_user_id");

                    b.HasIndex("WalletId")
                        .HasDatabaseName("ix_transactions_wallet_id");

                    b.ToTable("transactions", "overmoney_api");
                });

            modelBuilder.Entity("Overmoney.Api.DataAccess.Users.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("IX_Email");

                    b.HasIndex("Login")
                        .IsUnique()
                        .HasDatabaseName("IX_Login");

                    b.ToTable("users", "overmoney_api");
                });

            modelBuilder.Entity("Overmoney.Api.DataAccess.Wallets.WalletEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrencyId")
                        .HasColumnType("integer")
                        .HasColumnName("currency_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_wallets");

                    b.HasIndex("CurrencyId")
                        .HasDatabaseName("ix_wallets_currency_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_wallets_user_id");

                    b.ToTable("wallets", "overmoney_api");
                });

            modelBuilder.Entity("Overmoney.Api.DataAccess.Budgets.BudgetEntity", b =>
                {
                    b.HasOne("Overmoney.Api.DataAccess.Users.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_budgets_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Overmoney.Api.DataAccess.Budgets.BudgetLineEntity", b =>
                {
                    b.HasOne("Overmoney.Api.DataAccess.Budgets.BudgetEntity", "Budget")
                        .WithMany("BudgetLines")
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_budget_lines_budgets_budget_id");

                    b.HasOne("Overmoney.Api.DataAccess.Categories.CategoryEntity", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_budget_lines_categories_category_id");

                    b.Navigation("Budget");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Overmoney.Api.DataAccess.Categories.CategoryEntity", b =>
                {
                    b.HasOne("Overmoney.Api.DataAccess.Users.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_categories_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Overmoney.Api.DataAccess.Payees.PayeeEntity", b =>
                {
                    b.HasOne("Overmoney.Api.DataAccess.Users.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_payees_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Overmoney.Api.DataAccess.Transactions.AttachmentEntity", b =>
                {
                    b.HasOne("Overmoney.Api.DataAccess.Transactions.TransactionEntity", "Transaction")
                        .WithMany("Attachments")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_attachments_transactions_transaction_id");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("Overmoney.Api.DataAccess.Transactions.RecurringTransactionEntity", b =>
                {
                    b.HasOne("Overmoney.Api.DataAccess.Categories.CategoryEntity", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_recurring_transactions_categories_category_id");

                    b.HasOne("Overmoney.Api.DataAccess.Payees.PayeeEntity", "Payee")
                        .WithMany()
                        .HasForeignKey("PayeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_recurring_transactions_payees_payee_id");

                    b.HasOne("Overmoney.Api.DataAccess.Users.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_recurring_transactions_users_user_id");

                    b.HasOne("Overmoney.Api.DataAccess.Wallets.WalletEntity", "Wallet")
                        .WithMany()
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_recurring_transactions_wallets_wallet_id");

                    b.Navigation("Category");

                    b.Navigation("Payee");

                    b.Navigation("User");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("Overmoney.Api.DataAccess.Transactions.TransactionEntity", b =>
                {
                    b.HasOne("Overmoney.Api.DataAccess.Categories.CategoryEntity", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_transactions_categories_category_id");

                    b.HasOne("Overmoney.Api.DataAccess.Payees.PayeeEntity", "Payee")
                        .WithMany()
                        .HasForeignKey("PayeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_transactions_payees_payee_id");

                    b.HasOne("Overmoney.Api.DataAccess.Users.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_transactions_users_user_id");

                    b.HasOne("Overmoney.Api.DataAccess.Wallets.WalletEntity", "Wallet")
                        .WithMany()
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_transactions_wallets_wallet_id");

                    b.Navigation("Category");

                    b.Navigation("Payee");

                    b.Navigation("User");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("Overmoney.Api.DataAccess.Wallets.WalletEntity", b =>
                {
                    b.HasOne("Overmoney.Api.DataAccess.Currencies.CurrencyEntity", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_wallets_currencies_currency_id");

                    b.HasOne("Overmoney.Api.DataAccess.Users.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_wallets_users_user_id");

                    b.Navigation("Currency");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Overmoney.Api.DataAccess.Budgets.BudgetEntity", b =>
                {
                    b.Navigation("BudgetLines");
                });

            modelBuilder.Entity("Overmoney.Api.DataAccess.Transactions.TransactionEntity", b =>
                {
                    b.Navigation("Attachments");
                });
#pragma warning restore 612, 618
        }
    }
}
