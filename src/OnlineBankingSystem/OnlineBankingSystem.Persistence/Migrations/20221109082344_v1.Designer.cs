﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineBankingSystem.Persistence.Data;

#nullable disable

namespace OnlineBankingSystem.Persistence.Migrations
{
    [DbContext(typeof(OnlineBankingSystemDbContext))]
    [Migration("20221109082344_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BankAccountBankAccount", b =>
                {
                    b.Property<string>("BeneficiariesAccountNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BeneficiaryOfAccountNumber")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BeneficiariesAccountNumber", "BeneficiaryOfAccountNumber");

                    b.HasIndex("BeneficiaryOfAccountNumber");

                    b.ToTable("BankAccountBankAccount");
                });

            modelBuilder.Entity("OnlineBankingSystem.Domain.Entities.BankAccount", b =>
                {
                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("InterestRate")
                        .HasColumnType("float");

                    b.Property<double>("MinBalance")
                        .HasColumnType("float");

                    b.Property<string>("RoutingNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("AccountNumber");

                    b.HasIndex("CustomerId");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("OnlineBankingSystem.Domain.Entities.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ssn")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("OnlineBankingSystem.Domain.Entities.PersonalLoanApplication", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ApprovalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("InterestRate")
                        .HasColumnType("float");

                    b.Property<int>("Term")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("PersonalLoanApplications");
                });

            modelBuilder.Entity("OnlineBankingSystem.Domain.Entities.Transaction", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromAccountAccountNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FromAccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("ToAccountAccountNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ToAccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FromAccountAccountNumber");

                    b.HasIndex("ToAccountAccountNumber");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("BankAccountBankAccount", b =>
                {
                    b.HasOne("OnlineBankingSystem.Domain.Entities.BankAccount", null)
                        .WithMany()
                        .HasForeignKey("BeneficiariesAccountNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineBankingSystem.Domain.Entities.BankAccount", null)
                        .WithMany()
                        .HasForeignKey("BeneficiaryOfAccountNumber")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineBankingSystem.Domain.Entities.BankAccount", b =>
                {
                    b.HasOne("OnlineBankingSystem.Domain.Entities.Customer", "customer")
                        .WithMany("BankAccounts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");
                });

            modelBuilder.Entity("OnlineBankingSystem.Domain.Entities.PersonalLoanApplication", b =>
                {
                    b.HasOne("OnlineBankingSystem.Domain.Entities.Customer", "Customer")
                        .WithMany("PersonalLoanApplications")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("OnlineBankingSystem.Domain.Entities.Transaction", b =>
                {
                    b.HasOne("OnlineBankingSystem.Domain.Entities.BankAccount", "FromAccount")
                        .WithMany("SentTransactions")
                        .HasForeignKey("FromAccountAccountNumber");

                    b.HasOne("OnlineBankingSystem.Domain.Entities.BankAccount", "ToAccount")
                        .WithMany("ReceivedTransactions")
                        .HasForeignKey("ToAccountAccountNumber");

                    b.Navigation("FromAccount");

                    b.Navigation("ToAccount");
                });

            modelBuilder.Entity("OnlineBankingSystem.Domain.Entities.BankAccount", b =>
                {
                    b.Navigation("ReceivedTransactions");

                    b.Navigation("SentTransactions");
                });

            modelBuilder.Entity("OnlineBankingSystem.Domain.Entities.Customer", b =>
                {
                    b.Navigation("BankAccounts");

                    b.Navigation("PersonalLoanApplications");
                });
#pragma warning restore 612, 618
        }
    }
}
