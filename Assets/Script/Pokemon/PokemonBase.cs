using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName = "Pokemon/Create new Pokemon")]
public class PokemonBase : ScriptableObject
{
    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] int number;

    [SerializeField] string pokemonName;

    [SerializeField] PokemonType type1;

    [SerializeField] PokemonType type2;

    [SerializeField] int maxHp;

    [SerializeField] int attack;

    [SerializeField] int defense;

    [SerializeField] int specialAttack;

    [SerializeField] int specialDefense;

    [SerializeField] int speed;

    [SerializeField] List<LearnableMove> learnableMoves;

    public Sprite FrontSprite
    {
        get { return frontSprite; }
    }

    public Sprite BackSprite
    {
        get { return backSprite; }
    }

    public int Number
    {
        get { return number; }
    }

    public string PokemonName
    {
        get { return pokemonName; }
    }

    public PokemonType Type1
    {
        get { return type1; }
    }

    public PokemonType Type2
    {
        get { return type2; }
    }

    public int MaxHp
    {
        get { return maxHp; }
    }

    public int Attack
    {
        get { return attack; }
    }

    public int Defense
    {
        get { return defense; }
    }

    public int SpecialAttack
    {
        get { return specialAttack; }
    }

    public int SpecialDefense
    {
        get { return specialDefense; }
    }

    public int Speed
    {
        get { return speed; }
    }

    public List<LearnableMove> LearnableMoves
    {
        get { return learnableMoves; }
    }
}

[System.Serializable]
public class LearnableMove
{
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase MoveBase { get { return moveBase; } }
    public int Level { get { return level; } }
}

public enum PokemonType
{
    None,
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psychic,
    Bug,
    Rock,
    Ghost,
    Dragon,
    Dark,
    Steel,
    Fairy,
}

public class TypeChart
{
    static float[][] chart = {
        //                     NOR FIR WAT
        new float[] { 1f,  1f,   1f,  1f,  1f,  1f,  1f,  1f,  1f,  1f,  1f,  1f, 0.5f, 0f,  1f,  1f, 0.5f },
        new float[] { 1f, 0.5f, 0.5f, 1f,  2f,  2f,  1f,  1f,  1f,  1f,  1f,  2f, 0.5f, 1f, 0.5f, 1f,  2f },
        new float[] { 1f,  2f,  0.5f, 2f, 0.5f, 1f,  1f,  1f,  2f,  1f,  1f,  1f,  2f,  1f, 0.5f, 1f,  1f },
        new float[] { 1f,  1f,   2f, 0.5f,0.5f, 2f,  1f,  1f,  0f,  2f,  1f,  1f,  1f,  1f, 0.5f, 1f,  1f },
        new float[] { 1f, 0.5f,  2f,  2f, 0.5f, 1f,  1f, 0.5f, 2f, 0.5f, 1f, 0.5f, 2f,  1f, 0.5f, 1f, 0.5f },
        new float[] { 1f, 0.5f, 0.5f, 1f,  2f, 0.5f, 1f,  1f,  2f,  2f,  1f,  1f,  1f,  1f,  2f,  1f, 0.5f },
        new float[] { 2f,  1f,   1f,  1f,  1f,  2f,  1f, 0.5f, 1f, 0.5f, 0.5f, 0.5f, 2f, 0f, 1f,  2f,  2f },
        new float[] { 1f,  1f,   1f,  1f,  2f,  1f,  1f, 0.5f, 0.5f, 1f, 1f,  1f, 0.5f, 0.5f, 1f, 1f,  0f },
        new float[] { 1f,  2f,   1f,  2f, 0.5f, 1f,  1f,  2f,  1f,  0f,  1f, 0.5f, 2f,  1f,  1f,  1f,  2f },
        new float[] { 1f,  1f,   1f, 0.5f, 2f,  1f,  2f,  1f,  1f,  1f,  1f,  2f, 0.5f, 1f,  1f,  1f, 0.5f },
        new float[] { 1f,  1f,   1f,  1f,  1f,  1f,  2f,  2f,  1f,  1f, 0.5f, 1f,  1f,  1f,  1f,  0f, 0.5f },
        new float[] { 1f, 0.5f,  1f,  1f,  2f, 1f, 0.5f, 0.5f, 1f, 0.5f, 2f,  1f,  1f, 0.5f, 1f,  2f, 0.5f },
        new float[] { 1f,  2f,   1f,  1f,  1f,  2f, 0.5f, 1f, 0.5f, 2f,  1f,  2f,  1f,  1f,  1f,  1f, 0.5f },
        new float[] { 0f,  1f,   1f,  1f,  1f,  1f,  1f,  1f,  1f,  1f,  2f,  1f,  1f,  2f, 1f, 0.5f, 0.5f },
        new float[] { 1f,  1f,   1f,  1f,  1f,  1f,  1f,  1f,  1f,  1f,  1f,  1f,  1f,  1f,  2f,  1f,  0.5f},
        new float[] { 1f,  1f,   1f,  1f,  1f,  1f, 0.5f, 1f,  1f,  1f,  2f,  1f,  1f,  2f, 1f, 0.5f, 0.5f },
        new float[] { 1f, 0.5f, 0.5f, 0.5f, 1f, 2f,  1f,  1f,  1f,  1f,  1f,  1f,  2f,  1f,  1f,  1f,  0.5f }
    };

    public static float GetEffectiveness(PokemonType attackType, PokemonType defenseType)
    {
        if (attackType == PokemonType.None || defenseType == PokemonType.None)
        {
            return 1;
        }
        Debug.Log($"{attackType.ToString()} - {defenseType.ToString()}");

        int row = (int)attackType - 1;
        int col = (int)defenseType - 1;

        return chart[row][col];
    }
}