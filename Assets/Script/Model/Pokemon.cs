using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon
{
    public Pokemon(int id, string name, string type)
    {
        this.id = id;
        this.name = name;
        this.type = type;
    }

    public int id { get; set; }

    public string name { get; set; }

    public string type { get; set; }
}
