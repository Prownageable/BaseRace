using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Team
{
    public int currency;
    public string name;

    public List<GameObject> units = new List<GameObject>();

    public GameObject base_building;
    public GameObject research_building;

    public Team(string name)
    {
        this.name = name;
    }
}
