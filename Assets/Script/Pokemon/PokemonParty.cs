using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PokemonParty : MonoBehaviour
{
    [SerializeField] List<Pokemon> pokemons;

    void Start()
    {
        foreach (var poke in pokemons)
        {
            poke.Init();
        }
    }

    public Pokemon GetHealthyPokemon()
    {
        return pokemons.Where(p => p.HP > 0).FirstOrDefault();
    }

    public void AddPokemon(Pokemon newPokemon)
    {
        if (pokemons.Count < 6)
        {
            pokemons.Add(newPokemon);
        }
        else
        {
            // ADD TO PC
        }
    }
}
