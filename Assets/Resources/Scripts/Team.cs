using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Team
{
    public int currency;
    public string name;
    public float goldPerFive = 3.5f;

    private float rawCurrency = 0;
    private float timer = 0f;

    public List<GameObject> units = new List<GameObject>();

    public GameObject base_building;
    public GameObject research_building;

    public Team(string name)
    {
        this.name = name;
        this.currency = 40;
        this.rawCurrency = currency;
    }

    public void ReduceCurrency(float cost)
    {
        this.rawCurrency -= cost;
    }

    public void UpdateCurrency()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            rawCurrency += (goldPerFive / 5);
            timer = 0.0f;
        }
        currency = (int)rawCurrency;
    }
}
