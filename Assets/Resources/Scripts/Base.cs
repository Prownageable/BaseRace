using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Base : Structure
{
    private List<GameObject> spawnQueueTeam1 = new List<GameObject>();
    private List<GameObject> spawnQueueTeam2 = new List<GameObject>();

    public void CreateUnit(GameObject unit)
    {
        if (this.team.currency >= unit.GetComponent<Unit>().cost)
        {
            this.team.ReduceCurrency((int)unit.GetComponent<Unit>().cost);
            unit.GetComponent<Unit>().team = team;
            unit.GetComponent<Unit>().Start();
            unit.GetComponent<Unit>().AddToQueue();
            if (team == ObjectPool.base1.team)
            {
                spawnQueueTeam1.Add(unit);
            }
            else
            {
                spawnQueueTeam2.Add(unit);
            }
        }
    }

    public void UpdateSpawnQueue()
    {
        if (team == ObjectPool.base1.team)
        {
            for (int i = 0; i < spawnQueueTeam1.Count; i++)
            {
                GameObject unit = spawnQueueTeam1[i];
                unit.GetComponent<Unit>().spawnTime -= Time.deltaTime;
                if (unit.GetComponent<Unit>().spawnTime <= 0)
                {
                    unit.transform.position = new Vector3(this.transform.position.x, unit.gameObject.renderer.bounds.size.y / 2, this.transform.position.z);
                    unit.SetActive(true);
                    unit.GetComponent<Unit>().RemoveFromQueue();
                    spawnQueueTeam1.RemoveAt(i);
                }
            }
        }
        else
        {
            for (int i = 0; i < spawnQueueTeam2.Count; i++)
            {
                GameObject unit = spawnQueueTeam2[i];
                unit.GetComponent<Unit>().spawnTime -= Time.deltaTime;
                if (unit.GetComponent<Unit>().spawnTime <= 0)
                {
                    unit.transform.position = new Vector3(this.transform.position.x, unit.gameObject.renderer.bounds.size.y / 2, this.transform.position.z);
                    unit.SetActive(true);
                    spawnQueueTeam2.RemoveAt(i);
                }
            }
        }
    }

    public void SpawnSoldier()
    {
        for (int i = 0; i < ObjectPool.maxSoldiers; i++)
        {
            if (team == ObjectPool.base1.team)
            {
                if (!ObjectPool.soldiersTeam1[i].activeSelf && !ObjectPool.soldiersTeam1[i].GetComponent<Unit>().IsQueued())
                {
                    GameObject unit = ObjectPool.soldiersTeam1[i];
                    CreateUnit(unit);
                    return;
                }
            }
            else if (team == ObjectPool.base2.team)
            {
                if (!ObjectPool.soldiersTeam2[i].activeSelf && !ObjectPool.soldiersTeam2[i].GetComponent<Unit>().IsQueued())
                {
                    GameObject unit = ObjectPool.soldiersTeam2[i];
                    CreateUnit(unit);
                    return;
                }
            }
        }
    }

    public void SpawnSiege()
    {
        for (int i = 0; i < ObjectPool.maxSiegeUnits; i++)
        {
            if (team == ObjectPool.base1.team)
            {
                if (!ObjectPool.siegeUnitsTeam1[i].activeSelf)
                {
                    GameObject unit = ObjectPool.siegeUnitsTeam1[i];
                    CreateUnit(unit);
                    return;
                }
            }
            else if (team == ObjectPool.base2.team)
            {
                if (!ObjectPool.siegeUnitsTeam2[i].activeSelf)
                {
                    GameObject unit = ObjectPool.siegeUnitsTeam2[i];
                    CreateUnit(unit);
                    return;
                }
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        base.Start();
        renderer.material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpawnQueue();
        team.UpdateCurrency();
        base.Update();
    }
}
