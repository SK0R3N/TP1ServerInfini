﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Super_Cartes_Infinies.Data;

#nullable disable

namespace Super_Cartes_Infinies.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231004002205_CarteDepart")]
    partial class CarteDepart
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CardPlayer", b =>
                {
                    b.Property<int>("CartesId")
                        .HasColumnType("int");

                    b.Property<int>("PlayersId")
                        .HasColumnType("int");

                    b.HasKey("CartesId", "PlayersId");

                    b.HasIndex("PlayersId");

                    b.ToTable("PlayerCards", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "11111111-1111-1111-1111-111111111111",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ee9105cc-14f4-4fbe-9ad0-07dc29bf6e5f",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN@ADMIN.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAELwgYTah6IV/5/Or7qpUHhuW6FFMnvG2Zv5zTvKTFGbMfam3nqrDrBQK5bboJGsiSA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "79b908a2-0652-491f-ae23-26e5662a2ab4",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "11111111-1111-1111-1111-111111111111",
                            RoleId = "1"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<bool>("CarteDepart")
                        .HasColumnType("bit");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Attack = 5,
                            CarteDepart = true,
                            Defense = 2,
                            ImageUrl = "https://neural.love/cdn/ai-photostock/1eddfa43-6780-663c-947a-1d35f0d44870/0.jpg?Expires=1698796799&Signature=soKyPQf1CooT5ZIMqtzdMLiN51pbxifuOBqOmiMhFVAMPQJaR2i4trQgQKngTnpGLhZVqD2iUISD4nnRa0kr8i5F8xlZ9fOm1hpIlncTlUZNpHCdhgQHvoJCleurKoWgKKeuTbkngqBoBVLyJ14Tk3s4c20uqs7CscadNjOcog-EjzdxAXNg9wUOK1NGuPMwKQ7fTgEMBs2XSeN9-XDkItz65fg-KHcN-i0-RTyGjRZSD5inmz1h5RMhkONXgaWU-yRh3pb5hvsJVb2Z2MYIluQVHaEqaeLFoKw1wqxRfW077sOEe9FkiFZgV5BSAWGXJE4neun9yJlYdn48h7HgZw__&Key-Pair-Id=K2RFTOXRBNSROX ",
                            Name = "scout"
                        },
                        new
                        {
                            Id = 2,
                            Attack = 4,
                            CarteDepart = true,
                            Defense = 6,
                            ImageUrl = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/ea3b0661-ca92-4e8b-ba01-b4dd4c0b55b6/dfxyib9-aecaf51b-9ad0-417f-b2ea-5d80e2761e0a.jpg/v1/fill/w_768,h_676,q_75,strp/cat_knight__by_burningheart97_dfxyib9-fullview.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7ImhlaWdodCI6Ijw9Njc2IiwicGF0aCI6IlwvZlwvZWEzYjA2NjEtY2E5Mi00ZThiLWJhMDEtYjRkZDRjMGI1NWI2XC9kZnh5aWI5LWFlY2FmNTFiLTlhZDAtNDE3Zi1iMmVhLTVkODBlMjc2MWUwYS5qcGciLCJ3aWR0aCI6Ijw9NzY4In1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmltYWdlLm9wZXJhdGlvbnMiXX0.e0v1GeN4k_eK3V32xfMt03ZtGb8NHc2IqXxLQm_0BoM",
                            Name = "knight"
                        },
                        new
                        {
                            Id = 3,
                            Attack = 1,
                            CarteDepart = true,
                            Defense = 20,
                            ImageUrl = "https://static.displate.com/280x392/displate/2023-02-13/f5abf339614207edf2ab038d76d69e60_cf641f1d5c6d2e65af5f36d333c6162a.jpg ",
                            Name = "space"
                        },
                        new
                        {
                            Id = 4,
                            Attack = 3,
                            CarteDepart = true,
                            Defense = 4,
                            ImageUrl = "https://cdnb.artstation.com/p/assets/images/images/008/897/787/medium/weiss-hunt-ab8cbcd8dbb547028285e8d2d3b668f9.jpg?1515977383 ",
                            Name = "king"
                        },
                        new
                        {
                            Id = 5,
                            Attack = 6,
                            CarteDepart = true,
                            Defense = 3,
                            ImageUrl = "https://preview.redd.it/viking-cat-v0-xtmoosuhfrna1.png?width=640&crop=smart&auto=webp&s=5296a2aa8ed180d6592ce1e7abe65d8173619f00 ",
                            Name = "viking"
                        },
                        new
                        {
                            Id = 6,
                            Attack = 1,
                            CarteDepart = true,
                            Defense = 1,
                            ImageUrl = "https://globalnews.ca/wp-content/uploads/2023/02/BC-SPCA-injured-cat-Wilson.jpg?quality=85&strip=all",
                            Name = "hurt"
                        },
                        new
                        {
                            Id = 7,
                            Attack = 10,
                            CarteDepart = true,
                            Defense = 1,
                            ImageUrl = "https://pbs.twimg.com/profile_images/1459726145805508612/D6qSUw8W_400x400.jpg",
                            Name = "monster"
                        },
                        new
                        {
                            Id = 8,
                            Attack = 3,
                            CarteDepart = false,
                            Defense = 6,
                            ImageUrl = "https://external-preview.redd.it/cat-as-a-priest-using-the-new-sdxl-0-9-v0-yRZZ_DiuHfKd_sDsSwTE9Zv66IqqLzrJdaolXonRXy4.jpg?auto=webp&s=875e5142767cb6b58de8d7da5ba7f4aa20c75d3b ",
                            Name = "priest"
                        },
                        new
                        {
                            Id = 9,
                            Attack = 9,
                            CarteDepart = false,
                            Defense = 6,
                            ImageUrl = "https://i.pinimg.com/originals/ef/38/6a/ef386ab449cae924321692f10dffc783.jpg",
                            Name = "soldier"
                        },
                        new
                        {
                            Id = 10,
                            Attack = 2,
                            CarteDepart = false,
                            Defense = 8,
                            ImageUrl = "https://i.pinimg.com/1200x/ec/e3/61/ece361b7eaf1856cd71bd39da6990b2a.jpg",
                            Name = "sniper"
                        },
                        new
                        {
                            Id = 11,
                            Attack = 7,
                            CarteDepart = false,
                            Defense = 7,
                            ImageUrl = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/c2d7052e-4967-4f98-b017-a2bcbf7a8a8a/d86i2ic-6f26e7b5-05c4-4f01-afa4-5eec9c2ea315.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcL2MyZDcwNTJlLTQ5NjctNGY5OC1iMDE3LWEyYmNiZjdhOGE4YVwvZDg2aTJpYy02ZjI2ZTdiNS0wNWM0LTRmMDEtYWZhNC01ZWVjOWMyZWEzMTUuanBnIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.Png98n38gSpiZcDs1ReEffrgKBSD-pQgLbyy8Q8S66c ",
                            Name = "dragon"
                        },
                        new
                        {
                            Id = 12,
                            Attack = 10,
                            CarteDepart = false,
                            Defense = 10,
                            ImageUrl = "https://imagedelivery.net/x0RJTBjgra1v_IP6ikii7A/488a3ea3-b6af-4715-645e-e43a88e63e00/768w",
                            Name = "god"
                        },
                        new
                        {
                            Id = 13,
                            Attack = 6,
                            CarteDepart = false,
                            Defense = 6,
                            ImageUrl = "https://i.pinimg.com/1200x/4e/7a/cb/4e7acb16e93bc996c96bd6f489325004.jpg",
                            Name = "normal cat"
                        },
                        new
                        {
                            Id = 14,
                            Attack = 8,
                            CarteDepart = false,
                            Defense = 8,
                            ImageUrl = "https://images.halloweencostumes.ca/products/23232/1-1/catnip-the-cat-mascot-costume.jpg",
                            Name = "also a cat"
                        });
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EventIndex")
                        .HasColumnType("int");

                    b.Property<bool>("IsMatchCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPlayerATurn")
                        .HasColumnType("bit");

                    b.Property<int>("PlayerDataAId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerDataBId")
                        .HasColumnType("int");

                    b.Property<string>("UserAId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserBId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WinnerUserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlayerDataAId");

                    b.HasIndex("PlayerDataBId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.MatchPlayerData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MatchPlayersData");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.PlayableCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<int?>("MatchPlayerDataId")
                        .HasColumnType("int");

                    b.Property<int?>("MatchPlayerDataId1")
                        .HasColumnType("int");

                    b.Property<int?>("MatchPlayerDataId2")
                        .HasColumnType("int");

                    b.Property<int?>("MatchPlayerDataId3")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("MatchPlayerDataId");

                    b.HasIndex("MatchPlayerDataId1");

                    b.HasIndex("MatchPlayerDataId2");

                    b.HasIndex("MatchPlayerDataId3");

                    b.ToTable("PlayableCard");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IdentityUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.SerializedMatchEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<int?>("MatchId")
                        .HasColumnType("int");

                    b.Property<string>("SerializedEvent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.ToTable("SerializedMatchEvents");
                });

            modelBuilder.Entity("CardPlayer", b =>
                {
                    b.HasOne("Super_Cartes_Infinies.Models.Card", null)
                        .WithMany()
                        .HasForeignKey("CartesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Super_Cartes_Infinies.Models.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.Match", b =>
                {
                    b.HasOne("Super_Cartes_Infinies.Models.MatchPlayerData", "PlayerDataA")
                        .WithMany()
                        .HasForeignKey("PlayerDataAId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Super_Cartes_Infinies.Models.MatchPlayerData", "PlayerDataB")
                        .WithMany()
                        .HasForeignKey("PlayerDataBId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("PlayerDataA");

                    b.Navigation("PlayerDataB");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.PlayableCard", b =>
                {
                    b.HasOne("Super_Cartes_Infinies.Models.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Super_Cartes_Infinies.Models.MatchPlayerData", null)
                        .WithMany("BattleField")
                        .HasForeignKey("MatchPlayerDataId");

                    b.HasOne("Super_Cartes_Infinies.Models.MatchPlayerData", null)
                        .WithMany("CardsPile")
                        .HasForeignKey("MatchPlayerDataId1");

                    b.HasOne("Super_Cartes_Infinies.Models.MatchPlayerData", null)
                        .WithMany("Graveyard")
                        .HasForeignKey("MatchPlayerDataId2");

                    b.HasOne("Super_Cartes_Infinies.Models.MatchPlayerData", null)
                        .WithMany("Hand")
                        .HasForeignKey("MatchPlayerDataId3");

                    b.Navigation("Card");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.Player", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentityUser");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.SerializedMatchEvent", b =>
                {
                    b.HasOne("Super_Cartes_Infinies.Models.Match", null)
                        .WithMany("SerializedEvents")
                        .HasForeignKey("MatchId");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.Match", b =>
                {
                    b.Navigation("SerializedEvents");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.MatchPlayerData", b =>
                {
                    b.Navigation("BattleField");

                    b.Navigation("CardsPile");

                    b.Navigation("Graveyard");

                    b.Navigation("Hand");
                });
#pragma warning restore 612, 618
        }
    }
}
