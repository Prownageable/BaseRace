using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Base : Structure
{
    private List<GameObject> spawnQueue = new List<GameObject>();

    public void SpawnSoldier()
    {
        for (int i = 0; i < ObjectPool.maxSoldiers; i++)
        {
            if (!ObjectPool.soldiers[i].activeSelf)
            {
                GameObject unit = ObjectPool.soldiers[i];
                spawnQueue.Add(unit);
                return;
            }
        }
    }

    public void SpawnSiege()
    {
        for (int i = 0; i < ObjectPool.maxSiegeUnits; i++)
        {
            if (!ObjectPool.siegeUnits[i].activeSelf)
            {
                GameObject unit = ObjectPool.siegeUnits[i];
                spawnQueue.Add(unit);
                /*unit.transform.position = new Vector3(this.transform.position.x, unit.gameObject.renderer.bounds.size.y / 2, this.transform.position.z);
                unit.GetComponent<Unit>().team = team;
                unit.GetComponent<Unit>().Start();
                unit.SetActive(true);*/
                return;
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        //print("Spawnqueue length: " + spawnQueue.Count);

        for (int i = 0; i < spawnQueue.Count; i++)
        {            
            GameObject unit = spawnQueue[i];
            unit.GetComponent<Unit>().spawnTime -= Time.deltaTime;
            if (unit.GetComponent<Unit>().spawnTime <= 0)
            {
                unit.transform.position = new Vector3(this.transform.position.x, unit.gameObject.renderer.bounds.size.y / 2, this.transform.position.z);
                unit.GetComponent<Unit>().team = team;
                unit.GetComponent<Unit>().Start();
                unit.SetActive(true);
                spawnQueue.RemoveAt(i);
            }
        }

        base.Update();
    }
}
