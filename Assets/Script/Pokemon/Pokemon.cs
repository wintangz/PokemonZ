using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon
{
    public PokemonBase Base { get; set; }
    public int Level { get; set; }

    public int HP { get; set; }
    public List<Move> Moves { get; set; }

    public int MaxHp { get { return Mathf.FloorToInt((Base.MaxHp * Level) / 100f) + 10; } }
    public int Attack { get { return Mathf.FloorToInt((Base.Attack * Level) / 100f) + 5; } }
    public int Defense { get { return Mathf.FloorToInt((Base.Defense * Level) / 100f) + 5; } }
    public int SpecialAttack { get { return Mathf.FloorToInt((Base.SpecialAttack * Level) / 100f) + 5; } }
    public int SpecialDefense { get { return Mathf.FloorToInt((Base.SpecialDefense * Level) / 100f) + 5; } }
    public int Speed { get { return Mathf.FloorToInt((Base.Speed * Level) / 100f) + 5; } }

    public Pokemon(PokemonBase pBase, int level)
    {
        Base = pBase;
        Level = level;
        HP = MaxHp;

        Moves = new List<Move>();
        foreach (var move in Base.LearnableMoves)
        {
            if (move.Level <= level)
            {
                Moves.Add(new Move(move.MoveBase));
            }

            if (Moves.Count >= 4)
            {

            }
        }
    }
}
