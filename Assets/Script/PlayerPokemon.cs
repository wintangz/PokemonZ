using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPokemon : MonoBehaviour
{
    List<Pokemon> pokemons = new List<Pokemon>{
        new Pokemon(1, "Bulbasaur", "Leaf"),
        new Pokemon(2, "Ivysaur", "Leaf"),
        new Pokemon(3, "Venusaur", "Leaf"),
        new Pokemon(4, "Charmander", "Fire"),
        new Pokemon(5, "Charmeleon", "Fire"),
        new Pokemon(6, "Charizard", "Fire")
    };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
