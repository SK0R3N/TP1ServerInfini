using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class SeedTest
    {

        static public Card[] SeedCards()
        {
            var cards = new[]
                {
                    new Card{Id = 1,Name = "scout",Attack = 5,Defense = 2,ImageUrl = "https://neural.love/cdn/ai-photostock/1eddfa43-6780-663c-947a-1d35f0d44870/0.jpg?Expires=1698796799&Signature=soKyPQf1CooT5ZIMqtzdMLiN51pbxifuOBqOmiMhFVAMPQJaR2i4trQgQKngTnpGLhZVqD2iUISD4nnRa0kr8i5F8xlZ9fOm1hpIlncTlUZNpHCdhgQHvoJCleurKoWgKKeuTbkngqBoBVLyJ14Tk3s4c20uqs7CscadNjOcog-EjzdxAXNg9wUOK1NGuPMwKQ7fTgEMBs2XSeN9-XDkItz65fg-KHcN-i0-RTyGjRZSD5inmz1h5RMhkONXgaWU-yRh3pb5hvsJVb2Z2MYIluQVHaEqaeLFoKw1wqxRfW077sOEe9FkiFZgV5BSAWGXJE4neun9yJlYdn48h7HgZw__&Key-Pair-Id=K2RFTOXRBNSROX "
        },
                new Card  {  Id = 2,Name = "knight",Attack = 4,Defense = 6,ImageUrl = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/ea3b0661-ca92-4e8b-ba01-b4dd4c0b55b6/dfxyib9-aecaf51b-9ad0-417f-b2ea-5d80e2761e0a.jpg/v1/fill/w_768,h_676,q_75,strp/cat_knight__by_burningheart97_dfxyib9-fullview.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7ImhlaWdodCI6Ijw9Njc2IiwicGF0aCI6IlwvZlwvZWEzYjA2NjEtY2E5Mi00ZThiLWJhMDEtYjRkZDRjMGI1NWI2XC9kZnh5aWI5LWFlY2FmNTFiLTlhZDAtNDE3Zi1iMmVhLTVkODBlMjc2MWUwYS5qcGciLCJ3aWR0aCI6Ijw9NzY4In1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmltYWdlLm9wZXJhdGlvbnMiXX0.e0v1GeN4k_eK3V32xfMt03ZtGb8NHc2IqXxLQm_0BoM"
                },new Card  { Id = 3, Name = "space", Attack = 1, Defense = 20,ImageUrl = "https://static.displate.com/280x392/displate/2023-02-13/f5abf339614207edf2ab038d76d69e60_cf641f1d5c6d2e65af5f36d333c6162a.jpg "
                }, new Card {Id = 4, Name = "king",  Attack = 3, Defense = 4,ImageUrl = "https://cdnb.artstation.com/p/assets/images/images/008/897/787/medium/weiss-hunt-ab8cbcd8dbb547028285e8d2d3b668f9.jpg?1515977383"
                },  new Card{Id = 5, Name = "viking", Attack = 6, Defense = 3,   ImageUrl = "https://preview.redd.it/viking-cat-v0-xtmoosuhfrna1.png?width=640&crop=smart&auto=webp&s=5296a2aa8ed180d6592ce1e7abe65d8173619f00 "
                },new Card { Id = 6,Name = "hurt",  Attack = 1, Defense = 1, ImageUrl = "https://globalnews.ca/wp-content/uploads/2023/02/BC-SPCA-injured-cat-Wilson.jpg?quality=85&strip=all"
                }, new Card{Id = 7, Name = "monster",  Attack = 10,  Defense = 1,  ImageUrl = "https://pbs.twimg.com/profile_images/1459726145805508612/D6qSUw8W_400x400.jpg"
                }, new Card {Id = 8,  Name = "priest", Attack = 3, Defense = 6,ImageUrl = "https://external-preview.redd.it/cat-as-a-priest-using-the-new-sdxl-0-9-v0-yRZZ_DiuHfKd_sDsSwTE9Zv66IqqLzrJdaolXonRXy4.jpg?auto=webp&s=875e5142767cb6b58de8d7da5ba7f4aa20c75d3b "
                },new Card{ Id = 9,  Name = "soldier",    Attack = 9,  Defense = 6,  ImageUrl = "https://i.pinimg.com/originals/ef/38/6a/ef386ab449cae924321692f10dffc783.jpg"
                }, new Card{Id = 10, Name = "sniper",Attack = 2, Defense = 8,   ImageUrl = "https://i.pinimg.com/1200x/ec/e3/61/ece361b7eaf1856cd71bd39da6990b2a.jpg"
                }, new Card  { Id = 11,  Name = "dragon",   Attack = 7,  Defense = 7,ImageUrl = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/c2d7052e-4967-4f98-b017-a2bcbf7a8a8a/d86i2ic-6f26e7b5-05c4-4f01-afa4-5eec9c2ea315.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcL2MyZDcwNTJlLTQ5NjctNGY5OC1iMDE3LWEyYmNiZjdhOGE4YVwvZDg2aTJpYy02ZjI2ZTdiNS0wNWM0LTRmMDEtYWZhNC01ZWVjOWMyZWEzMTUuanBnIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.Png98n38gSpiZcDs1ReEffrgKBSD-pQgLbyy8Q8S66c "
                }, new Card{    Id = 12,      Name = "god",   Attack = 10,     Defense = 10,  ImageUrl = "https://imagedelivery.net/x0RJTBjgra1v_IP6ikii7A/488a3ea3-b6af-4715-645e-e43a88e63e00/768w"
                },new Card{  Id = 13,    Name = "normal cat",  Attack = 6, Defense = 6, ImageUrl = "https://i.pinimg.com/1200x/4e/7a/cb/4e7acb16e93bc996c96bd6f489325004.jpg"
                }, new Card{  Id = 14, Name = "also a cat", Attack = 8,  Defense = 8,  ImageUrl = "https://images.halloweencostumes.ca/products/23232/1-1/catnip-the-cat-mascot-costume.jpg"
                }
            };
            return cards;
        }
        static public Player[] SeedPlayers(List<Card> card)
        {
            var players = new List<Player>();
            var gamerNames = new List<string>
        {
        "ShadowStrike",
        "DragonSlayer",
        "EpicGamer",
        "PixelMaster",
        "NinjaWarrior",
        "MageWizard",
        "CyberPunk",
        "GalacticHero",
        "SwordMaster",
        "StealthAssassin"
        };
            for (int i = 0; i < 10; i++)
            {
                var player = new Player
                {
                    
                    Name = gamerNames[i],
                    Money = 1000,
                    IdentityUserId = "user" + (i + 1)
                };

                var cards = card;


                player.Cartes = cards;
                players.Add(player);
            }

            return players.ToArray();
        }


    }
}
