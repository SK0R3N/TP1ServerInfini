using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Models;
using System.Reflection.Emit;
using static System.Net.WebRequestMethods;

namespace Super_Cartes_Infinies.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" }
            );

        // Creation des users
        PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
        IdentityUser admin = new IdentityUser
        {
            Id = "11111111-1111-1111-1111-111111111111",
            Email = "admin@admin.com",
            UserName = "admin",
            // La comparaison d'identity se fait avec les versions normalisés
            NormalizedEmail = "ADMIN@ADMIN.COM",
            NormalizedUserName = "ADMIN@ADMIN.COM",
            EmailConfirmed = true
        };
        // On encrypte le mot de passe
        admin.PasswordHash = hasher.HashPassword(admin, "Passw0rd!");
        builder.Entity<IdentityUser>().HasData(admin);

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { UserId = admin.Id, RoleId = "1" }
        );

        Card card1 = new Card
        {
            Id = 1,
            Name = "scout",
            Attack = 5,
            Defense = 2,
            ImageUrl = "https://neural.love/cdn/ai-photostock/1eddfa43-6780-663c-947a-1d35f0d44870/0.jpg?Expires=1698796799&Signature=soKyPQf1CooT5ZIMqtzdMLiN51pbxifuOBqOmiMhFVAMPQJaR2i4trQgQKngTnpGLhZVqD2iUISD4nnRa0kr8i5F8xlZ9fOm1hpIlncTlUZNpHCdhgQHvoJCleurKoWgKKeuTbkngqBoBVLyJ14Tk3s4c20uqs7CscadNjOcog-EjzdxAXNg9wUOK1NGuPMwKQ7fTgEMBs2XSeN9-XDkItz65fg-KHcN-i0-RTyGjRZSD5inmz1h5RMhkONXgaWU-yRh3pb5hvsJVb2Z2MYIluQVHaEqaeLFoKw1wqxRfW077sOEe9FkiFZgV5BSAWGXJE4neun9yJlYdn48h7HgZw__&Key-Pair-Id=K2RFTOXRBNSROX ",
            CarteDepart = true
        };

        Card card2 = new Card
        {
            Id = 2,
            Name = "knight",
            Attack = 4,
            Defense = 6,
            CarteDepart = true,
            ImageUrl = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/ea3b0661-ca92-4e8b-ba01-b4dd4c0b55b6/dfxyib9-aecaf51b-9ad0-417f-b2ea-5d80e2761e0a.jpg/v1/fill/w_768,h_676,q_75,strp/cat_knight__by_burningheart97_dfxyib9-fullview.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7ImhlaWdodCI6Ijw9Njc2IiwicGF0aCI6IlwvZlwvZWEzYjA2NjEtY2E5Mi00ZThiLWJhMDEtYjRkZDRjMGI1NWI2XC9kZnh5aWI5LWFlY2FmNTFiLTlhZDAtNDE3Zi1iMmVhLTVkODBlMjc2MWUwYS5qcGciLCJ3aWR0aCI6Ijw9NzY4In1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmltYWdlLm9wZXJhdGlvbnMiXX0.e0v1GeN4k_eK3V32xfMt03ZtGb8NHc2IqXxLQm_0BoM"
        };

        Card card3 = new Card
        {
            Id = 3,
            Name = "space",
            Attack = 1,
            Defense = 20,
            CarteDepart = true,
            ImageUrl = "https://static.displate.com/280x392/displate/2023-02-13/f5abf339614207edf2ab038d76d69e60_cf641f1d5c6d2e65af5f36d333c6162a.jpg "
        };

        Card card4 = new Card
        {
            Id = 4,
            Name = "king",
            Attack = 3,
            Defense = 4,
            CarteDepart = true,
            ImageUrl = "https://cdnb.artstation.com/p/assets/images/images/008/897/787/medium/weiss-hunt-ab8cbcd8dbb547028285e8d2d3b668f9.jpg?1515977383 "
        };

        Card card5 = new Card
        {
            Id = 5,
            Name = "viking",
            Attack = 6,
            Defense = 3,
            CarteDepart = true,
            ImageUrl = "https://preview.redd.it/viking-cat-v0-xtmoosuhfrna1.png?width=640&crop=smart&auto=webp&s=5296a2aa8ed180d6592ce1e7abe65d8173619f00 "
        };

        Card card6 = new Card
        {
            Id = 6,
            Name = "hurt",
            Attack = 1,
            Defense = 1,
            CarteDepart = true,
            ImageUrl = "https://globalnews.ca/wp-content/uploads/2023/02/BC-SPCA-injured-cat-Wilson.jpg?quality=85&strip=all"
        };

        Card card7 = new Card
        {
            Id = 7,
            Name = "monster",
            Attack = 10,
            Defense = 1,
            CarteDepart = true,
            ImageUrl = "https://pbs.twimg.com/profile_images/1459726145805508612/D6qSUw8W_400x400.jpg"
        };

        Card card8 = new Card
        {
            Id = 8,
            Name = "priest",
            Attack = 3,
            Defense = 6,
            CarteDepart = false,
            ImageUrl = "https://external-preview.redd.it/cat-as-a-priest-using-the-new-sdxl-0-9-v0-yRZZ_DiuHfKd_sDsSwTE9Zv66IqqLzrJdaolXonRXy4.jpg?auto=webp&s=875e5142767cb6b58de8d7da5ba7f4aa20c75d3b "
        };

        Card card9 = new Card
        {
            Id = 9,
            Name = "soldier",
            Attack = 9,
            Defense = 6,
            CarteDepart = false,
            ImageUrl = "https://i.pinimg.com/originals/ef/38/6a/ef386ab449cae924321692f10dffc783.jpg"
        };

        Card card10 = new Card
        {
            Id = 10,
            Name = "sniper",
            Attack = 2,
            Defense = 8,
            CarteDepart = false,
            ImageUrl = "https://i.pinimg.com/1200x/ec/e3/61/ece361b7eaf1856cd71bd39da6990b2a.jpg"
        };

        Card card11 = new Card
        {
            Id = 11,
            Name = "dragon",
            Attack = 7,
            Defense = 7,
            CarteDepart = false,
            ImageUrl = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/c2d7052e-4967-4f98-b017-a2bcbf7a8a8a/d86i2ic-6f26e7b5-05c4-4f01-afa4-5eec9c2ea315.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcL2MyZDcwNTJlLTQ5NjctNGY5OC1iMDE3LWEyYmNiZjdhOGE4YVwvZDg2aTJpYy02ZjI2ZTdiNS0wNWM0LTRmMDEtYWZhNC01ZWVjOWMyZWEzMTUuanBnIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.Png98n38gSpiZcDs1ReEffrgKBSD-pQgLbyy8Q8S66c "
        };

        Card card12 = new Card
        {
            Id = 12,
            Name = "god",
            Attack = 10,
            Defense = 10,
            CarteDepart = false,
            ImageUrl = "https://imagedelivery.net/x0RJTBjgra1v_IP6ikii7A/488a3ea3-b6af-4715-645e-e43a88e63e00/768w"
        };

        Card card13 = new Card
        {
            Id = 13,
            Name = "normal cat",
            Attack = 6,
            Defense = 6,
            CarteDepart = false,
            ImageUrl = "https://i.pinimg.com/1200x/4e/7a/cb/4e7acb16e93bc996c96bd6f489325004.jpg"
        };

        Card card14 = new Card
        {
            Id = 14,
            Name = "also a cat",
            Attack = 8,
            Defense = 8,
            CarteDepart = false,
            ImageUrl = "https://images.halloweencostumes.ca/products/23232/1-1/catnip-the-cat-mascot-costume.jpg"
        };
        builder.Entity<Card>().HasData(card1, card2, card3, card4, card5, card6, card7, card8, card9, card10, card11, card12, card13, card14);


        // TODO: Générer le seedpublic int Id { get; set; }

        builder.Entity<Match>()
            .HasOne(m => m.PlayerDataA)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Match>()
            .HasOne(m => m.PlayerDataB)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Player>()
            .HasMany(p => p.Cartes)
            .WithMany(c => c.Players)
            .UsingEntity(j => j.ToTable("PlayerCards"));
    }

    public DbSet<Card> Cards { get; set; } = default!;

    public DbSet<Player> Players { get; set; } = default!;

    public DbSet<Match> Matches { get; set; } = default!;

    public DbSet<MatchPlayerData> MatchPlayersData { get; set; } = default!;
    public DbSet<SerializedMatchEvent> SerializedMatchEvents { get; set; } = default!;
}

