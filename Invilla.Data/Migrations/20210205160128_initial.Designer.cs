﻿// <auto-generated />
using System;
using Invilla.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Invilla.Data.Migrations
{
    [DbContext(typeof(InvillaContext))]
    [Migration("20210205160128_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Invilla.Domain.Entity.FriendsEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("Invilla.Domain.Entity.GamesEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("FullGameName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Loaned")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Invilla.Domain.Entity.LoansEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("FriendId")
                        .HasColumnType("bigint");

                    b.Property<long?>("GameId")
                        .HasColumnType("bigint");

                    b.Property<long>("IdFriend")
                        .HasColumnType("bigint");

                    b.Property<long>("IdGames")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("LoanDateBegin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LoanDateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FriendId");

                    b.HasIndex("GameId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("Invilla.Domain.Entity.LoginEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IdRole")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("Invilla.Domain.Entity.RolesEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Invilla.Domain.Entity.LoansEntity", b =>
                {
                    b.HasOne("Invilla.Domain.Entity.FriendsEntity", "Friend")
                        .WithMany()
                        .HasForeignKey("FriendId");

                    b.HasOne("Invilla.Domain.Entity.GamesEntity", "Game")
                        .WithMany("LoansGames")
                        .HasForeignKey("GameId");

                    b.Navigation("Friend");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Invilla.Domain.Entity.LoginEntity", b =>
                {
                    b.HasOne("Invilla.Domain.Entity.RolesEntity", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Invilla.Domain.Entity.GamesEntity", b =>
                {
                    b.Navigation("LoansGames");
                });
#pragma warning restore 612, 618
        }
    }
}
