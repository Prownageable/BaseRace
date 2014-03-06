using UnityEngine;
using System.Collections;

public class Base : Structure
{
    public void SpawnSoldier()
    {
        for (int i = 0; i < ObjectPool.maxSoldiers; i++)
        {
            if (!ObjectPool.soldiers[i].activeSelf)
            {
                GameObject unit = ObjectPool.soldiers[i];
                unit.transform.position = new Vector3(this.transform.position.x, unit.gameObject.renderer.bounds.size.y / 2, this.transform.position.z);
                unit.GetComponent<Unit>().team = team;
                unit.GetComponent<Unit>().Start();
                unit.SetActive(true);
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
                unit.transform.position = new Vector3(this.transform.position.x, unit.gameObject.renderer.bounds.size.y / 2, this.transform.position.z);
                unit.GetComponent<Unit>().team = team;
                unit.GetComponent<Unit>().Start();
                unit.SetActive(true);
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
        base.Update();
    }
}