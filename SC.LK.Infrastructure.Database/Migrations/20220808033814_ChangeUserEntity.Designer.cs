﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SC.LK.Infrastructure.Database.Contexts;

#nullable disable

namespace SC.LK.Infrastructure.Database.Migrations
{
    [DbContext(typeof(ScanCityLKContext))]
    [Migration("20220808033814_Change user entity")]
    partial class Changeuserentity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ContractorEntityUserEntity", b =>
                {
                    b.Property<Guid>("UsersId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("СontractorId")
                        .HasColumnType("char(36)");

                    b.HasKey("UsersId", "СontractorId");

                    b.HasIndex("СontractorId");

                    b.ToTable("ContractorEntityUserEntity");
                });

            modelBuilder.Entity("SC.LK.Application.Domains.Entities.BalanceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Amout")
                        .HasColumnType("decimal(65,30)");

                    b.Property<Guid>("BonusesId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ContractorId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("BonusesId");

                    b.HasIndex("ContractorId");

                    b.ToTable("Balances");
                });

            modelBuilder.Entity("SC.LK.Application.Domains.Entities.BillingFaceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("INN")
                        .HasColumnType("longtext");

                    b.Property<string>("KPP")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<Guid>("PaymentSystemId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("СontractorId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PaymentSystemId");

                    b.HasIndex("СontractorId");

                    b.ToTable("BillingFaces");
                });

            modelBuilder.Entity("SC.LK.Application.Domains.Entities.BonusesEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("BonusesEntity");
                });

            modelBuilder.Entity("SC.LK.Application.Domains.Entities.ContractorEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("KeysId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("ParentContractorId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("Partner")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("PaymentSystem")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("KeysId");

                    b.HasIndex("ParentContractorId");

                    b.ToTable("Contractors");
                });

            modelBuilder.Entity("SC.LK.Application.Domains.Entities.DivisionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("Host")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("PIN")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("СontractorId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("СontractorId");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("SC.LK.Application.Domains.Entities.KeysEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("PrivateKey")
                        .HasColumnType("longtext");

                    b.Property<string>("PublicKey")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Keys");
                });

            modelBuilder.Entity("SC.LK.Application.Domains.Entities.PaymentSystemEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("MainUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Token")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("PaymentSystem");
                });

            modelBuilder.Entity("SC.LK.Application.Domains.Entities.PricesEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("CountDays")
                        .HasColumnType("int");

                    b.Property<string>("Frequency")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("PricesEntity");
                });

            modelBuilder.Entity("SC.LK.Application.Domains.Entities.RoleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AccessType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("SC.LK.Application.Domains.Entities.SubscriptionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PricePositionId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ValidityPeriod")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("PricePositionId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("SC.LK.Application.Domains.Entities.TerminalEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("AddedScanner")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Deviceid")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("DivisionId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("SubscriptionId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.HasIndex("SubscriptionId")
                        .IsUnique();

                    b.ToTable("Terminals");
                });

            modelBuilder.Entity("SC.LK.Application.Domains.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AuthCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Family")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsDelete")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Login")
                        .HasColumnType("longtext");

                    b.Property<Guid>("MainContractor")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Parent")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.Property<int>("RoleType")
                        .HasColumnType("int");

                    b.Property<string>("Token")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ContractorEntityUserEntity", b =>
                {
                    b.HasOne("SC.LK.Application.Domains.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SC.LK.Application.Domains.Entities.ContractorEntity", null)
                        .WithMany()
                        .HasForeignKey("СontractorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SC.LK.Application.Domains.Entities.BalanceEntity", b =>
                {
                    b.HasOne("SC.LK.Application.Domains.Entities.BonusesEntity", "Bonuses")
                        .WithMany()
                        .HasForeignKey("BonusesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SC.LK.Application.Domains.Entities.ContractorEntity", "Contractor")
                        .WithMany()
                        .HasForeignKey("ContractorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bonuses");

                    b.Navigation("Contractor");
                });

            modelBuilder.Entity("SC.LK.Application.Domains.Entities.BillingFaceEntity", b =>
                {
                    b.HasOne("SC.LK.Application.Domains.Entities.PaymentSystemEntity", "PaymentSystem")
                        .WithMany()
                        .HasForeignKey("PaymentSystemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SC.LK.Application.Domains.Entities.ContractorEntity", "Сontractor")
                        .WithMany("BillingFaces")
                        .HasForeignKey("СontractorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentSystem");

                    b.Navigation("Сontractor");
                });

            modelBuilder.Entity("SC.LK.Application.Domains.Entities.ContractorEntity", b =>
                {
                    b.HasOne("SC.LK.Application.Domains.Entities.KeysEntity", "Keys")
                        .WithMany()
                        .HasForeignKey("KeysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SC.LK.Application.Domains.Entities.ContractorEntity", "ParentContractor")
                        .WithMany("ChildContractors")
                        .HasForeignKey("ParentContractorId");

                    b.Navigation("Keys");

                    b.Navigation("ParentContractor");
                });

            modelBuilder.Entity("SC.LK.Application.Domains.Entities.DivisionEntity", b =>
                {
                    b.HasOne("SC.LK.Application.Domains.Entities.ContractorEntity", "Сontractor")
                        .WithMany("Division")
                        .HasForeignKey("СontractorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Сontractor");
                });

            modelBuilder.Entity("SC.LK.Application.Domains.Entities.SubscriptionEntity", b =>
                {
                    b.HasOne("SC.LK.Application.Domains.Entities.PricesEntity", "PricePosition")
                        .WithMany()
                        .HasForeignKey("PricePositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PricePosition");
                });

            modelBuilder.Entity("SC.LK.Application.Domains.Entities.TerminalEntity", b =>
                {
                    b.HasOne("SC.LK.Application.Domains.Entities.DivisionEntity", "Division")
                        .WithMany("Terminals")
                        .HasForeignKey("DivisionId");

                    b.HasOne("SC.LK.Application.Domains.Entities.SubscriptionEntity", "Subscription")
                        .WithOne("Terminal")
                        .HasForeignKey("SC.LK.Application.Domains.Entities.TerminalEntity", "SubscriptionId");

                    b.Navigation("Division");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("SC.LK.Application.Domains.Entities.UserEntity", b =>
                {
                    b.HasOne("SC.LK.Application.Domains.Entities.RoleEntity", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("SC.LK.Application.Domains.Entities.ContractorEntity", b =>
                {
                    b.Navigation("BillingFaces");

                    b.Navigation("ChildContractors");

                    b.Navigation("Division");
                });

            modelBuilder.Entity("SC.LK.Application.Domains.Entities.DivisionEntity", b =>
                {
                    b.Navigation("Terminals");
                });

            modelBuilder.Entity("SC.LK.Application.Domains.Entities.SubscriptionEntity", b =>
                {
                    b.Navigation("Terminal")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
