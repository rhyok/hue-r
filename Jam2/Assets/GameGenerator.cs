using UnityEngine;
using System.Collections;
using System;

public class GameGenerator : MonoBehaviour {
    ArrayList phrase1 = new ArrayList();
    ArrayList phrase2 = new ArrayList();

    ArrayList fpsSuffixes = new ArrayList();
    ArrayList rtsSuffixes = new ArrayList();
    ArrayList simSuffixes = new ArrayList();
    ArrayList rpgSuffixes = new ArrayList();
    ArrayList fightSuffixes = new ArrayList();
    ArrayList racingSuffixes = new ArrayList();
    ArrayList casualSuffixes = new ArrayList();

    Era currentEra;
    System.Random rand;

    void Start()
    {
        phrase1.Add("The Elder ");
        phrase1.Add("Call of ");
        phrase1.Add("League of ");
        phrase1.Add("Gun ");
        phrase1.Add("Jump ");
        phrase1.Add("World of ");
        phrase1.Add("Tower of ");
        phrase1.Add("Guild ");
        phrase1.Add("Dark ");
        phrase1.Add("Legend of ");
        phrase1.Add("Sexy ");
        phrase1.Add("Shoe ");
        phrase1.Add("Vector ");
        phrase1.Add("Cavern ");
        phrase1.Add("Dungeons and ");
        phrase1.Add("Combat ");
        phrase1.Add("Virtual ");
        phrase1.Add("Escape the ");
        phrase1.Add("Heart of the ");
        phrase1.Add("Blast ");
        phrase1.Add("Guns of the ");
        phrase1.Add("Iron ");
        phrase1.Add("Pirates vs ");
        phrase1.Add("Super ");
        phrase1.Add("Nuclear ");
        phrase1.Add("Elite ");
        phrase1.Add("Fishing ");
        phrase1.Add("Honto ni ");

        phrase2.Add("Barkleys");
        phrase2.Add("Men");
        phrase2.Add("Trains");
        phrase2.Add("Matrices");
        phrase2.Add("Dance");
        phrase2.Add("Demons");
        phrase2.Add("Eternities");
        phrase2.Add("Tansens");
        phrase2.Add("Cotton");
        phrase2.Add("Stories");
        phrase2.Add("Heroes");
        phrase2.Add("Masters");
        phrase2.Add("Gangs");
        phrase2.Add("Escape");
        phrase2.Add("Combat");
        phrase2.Add("Crafting");
        phrase2.Add("Eaters");
        phrase2.Add("Catmen");
        phrase2.Add("Entropy");
        phrase2.Add("Trigger");
        phrase2.Add("Italians");
        phrase2.Add("Creed");
        phrase2.Add("Gloop");
        phrase2.Add("Classes");
        phrase2.Add("Negative Infinity");
        phrase2.Add("Fantasies");
        phrase2.Add("Link");
        phrase2.Add("Farming");
        phrase2.Add("Jams");

        rtsSuffixes.Add(": The Strategy Game");
        rtsSuffixes.Add(": Commander");
        rtsSuffixes.Add(" Keeper");
        rtsSuffixes.Add(": Strategic Combat");
        rtsSuffixes.Add(": Control is Your's");
        rtsSuffixes.Add(": The Real-Time Strategy Game");
        rtsSuffixes.Add(" Chief");
        rtsSuffixes.Add(": Clan War");
        rtsSuffixes.Add(": Thawing Throne");
        rtsSuffixes.Add(" Armies United");
        rtsSuffixes.Add("craft");
        rtsSuffixes.Add(" War");

        fpsSuffixes.Add(" Arena");
        fpsSuffixes.Add(" Warfare");
        fpsSuffixes.Add(": Run-And-Gun");
        fpsSuffixes.Add(": The First-Person Shooter");
        fpsSuffixes.Add(" Tournament");
        fpsSuffixes.Add(" Episode 1");
        fpsSuffixes.Add(" Edge");
        fpsSuffixes.Add(": Hell on Mars");
        fpsSuffixes.Add(" 1942");
        fpsSuffixes.Add(" Revenge");
        fpsSuffixes.Add(" Infinite");
        fpsSuffixes.Add(" Offensive");

        fightSuffixes.Add(" Fighter");
        fightSuffixes.Add(" Turbo");
        fightSuffixes.Add(": The Universal Champion");
        fightSuffixes.Add(": Combat Clash");
        fightSuffixes.Add(" Alpha");
        fightSuffixes.Add(": Melee is Magic");
        fightSuffixes.Add(" Brawl");
        fightSuffixes.Add(" Scuffle");
        fightSuffixes.Add(": The Fighting Game");
        fightSuffixes.Add(": Close Quarters Combat");

        racingSuffixes.Add(" Racing");
        racingSuffixes.Add(" Kart");
        racingSuffixes.Add(": Gotta Go Fast");
        racingSuffixes.Add(" Drive");
        racingSuffixes.Add(" Derby");
        racingSuffixes.Add(" Over the Road Racing");
        racingSuffixes.Add(" Riders");

        casualSuffixes.Add(" vs Zombies");
        casualSuffixes.Add(" Birds");
        casualSuffixes.Add(" Sports");
        casualSuffixes.Add(" Party");
        casualSuffixes.Add(" Dash");
        casualSuffixes.Add(" Mania");
        casualSuffixes.Add(" Tennis");
        casualSuffixes.Add(" Basketball");
        casualSuffixes.Add(" Soccer");

        rand = new System.Random();
    }

    public Game generateGame()
    {
        Game game = new Game();

        //Genre
        System.Array genres = Enum.GetValues(typeof(Genre));
        game.genre = (Genre)genres.GetValue(rand.Next(genres.Length));

        //Network
        System.Array networkTypes = Enum.GetValues(typeof(NetworkType));
        game.networkRequirement = (NetworkType)networkTypes.GetValue(rand.Next(networkTypes.Length));

        //Era
        game.era = currentEra;

        //Game name
        string name = "";
        name += (string)phrase1[rand.Next(phrase1.Count)] + (string)phrase2[rand.Next(phrase2.Count)];
        switch (game.genre)
        {
            case Genre.RTS:
                name += (string)rtsSuffixes[rand.Next(rtsSuffixes.Count)];
                break;
            case Genre.FPS:
                name += (string)fpsSuffixes[rand.Next(fpsSuffixes.Count)];
                break;
            case Genre.RPG:
                name += (string)rpgSuffixes[rand.Next(rpgSuffixes.Count)];
                break;
            case Genre.SIM:
                name += (string)simSuffixes[rand.Next(simSuffixes.Count)];
                break;
            case Genre.FIGHING:
                name += (string)fightSuffixes[rand.Next(fightSuffixes.Count)];
                break;
            case Genre.RACING:
                name += (string)racingSuffixes[rand.Next(racingSuffixes.Count)];
                break;
            case Genre.CASUAL:
                name += (string)casualSuffixes[rand.Next(casualSuffixes.Count)];
                break;
            default:
                break;
        }
       

        return null;
    }
}