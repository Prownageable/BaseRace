using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ObjectPool
{
    public const int maxSoldiers = 50;
    public const int maxSiegeUnits = 25;

    public static GameObject[] soldiersTeam1 = new GameObject[maxSoldiers];
    public static GameObject[] soldiersTeam2 = new GameObject[maxSoldiers];

    public static GameObject[] siegeUnitsTeam1 = new GameObject[maxSoldiers];
    public static GameObject[] siegeUnitsTeam2 = new GameObject[maxSoldiers];

    public static Base base1;
    public static Base base2;

    public static Team team1;
    public static Team team2;

    public static void Init()
    {
        Debug.Log("Init pool");
        Object soldier = Resources.Load("Prefabs/Units/Soldier");
        Object siegeUnit = Resources.Load("Prefabs/Units/Siege");

        GameObject units = new GameObject("Units");
        GameObject soldierParent = new GameObject("Soldiers");
        GameObject siegeParent = new GameObject("Siege units");
        soldierParent.transform.parent = units.transform;
        siegeParent.transform.parent = units.transform;

        for (int i = 0; i < maxSoldiers; i++)
        {
<<<<<<< HEAD
            soldiers[i] = (GameObject) MonoBehaviour.Instantiate(soldier, new Vector3(0, 0, 0), Quaternion.identity);
            soldiers[i].SetActive(false);
            soldiers[i].transform.parent = soldierParent.transform;
        }
        for (int i = 0; i < maxSiegeUnits; i++)
        {
            siegeUnits[i] = (GameObject)MonoBehaviour.Instantiate(siegeUnit, new Vector3(0, 0, 0), Quaternion.identity);
            siegeUnits[i].SetActive(false);
            siegeUnits[i].transform.parent = siegeParent.transform;
=======
            soldiersTeam1[i] = (GameObject)MonoBehaviour.Instantiate(soldier, new Vector3(100, -10, 0), Quaternion.identity);
            soldiersTeam1[i].SetActive(false);

            soldiersTeam2[i] = (GameObject)MonoBehaviour.Instantiate(soldier, new Vector3(-100, -10, 0), Quaternion.identity);
            soldiersTeam2[i].SetActive(false);
        }
        for (int i = 0; i < maxSiegeUnits; i++)
        {
            siegeUnitsTeam1[i] = (GameObject)MonoBehaviour.Instantiate(siegeUnit, new Vector3(100, -10, 0), Quaternion.identity);
            siegeUnitsTeam1[i].SetActive(false);

            siegeUnitsTeam2[i] = (GameObject)MonoBehaviour.Instantiate(siegeUnit, new Vector3(-100, -10, 0), Quaternion.identity);
            siegeUnitsTeam2[i].SetActive(false);
>>>>>>> e61df6bb02d26fd23888b5fa5b861b0a0e3009d8
        }

        base1 = GameObject.Find("Base1").GetComponent<Base>();
        base2 = GameObject.Find("Base2").GetComponent<Base>();
        team1 = new Team("Rik");
        team2 = new Team("Jeroen");
        Debug.Log(team1.name);
        Debug.Log(team2.name);
        base1.team = team1;
        team1.base_building = base1.gameObject;
        base2.team = team2;
        team2.base_building = base2.gameObject;
    }

    public static void DeleteGameObject(GameObject go)
    {
        go.SetActive(false);
    }

    public static Team getEnemyTeam(Team t)
    {
        if (t == team1)
            return team2;
        else
            return team1;
    }

    public static GameObject[] getEnemySoldiers(Team t)
    {
        if (t == team1)
        {
            return soldiersTeam2;
        }
        else
        {
            return soldiersTeam1;
        }
    }

    public static GameObject[] getEnemySiegeUnits(Team t)
    {
        if (t == team1)
        {
            return siegeUnitsTeam2;
        }
        else
        {
            return siegeUnitsTeam1;
        }
    }
}
