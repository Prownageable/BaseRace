using UnityEngine;
using System.Collections;

public static class ObjectPool
{
    public const int maxSoldiers = 50;
    public const int maxSiegeUnits = 25;

    public static GameObject[] soldiers = new GameObject[maxSoldiers];
    public static GameObject[] siegeUnits = new GameObject[maxSoldiers];

    public static Base base1;
    public static Base base2;

    public static Team team1 = new Team("Rik");
    public static Team team2 = new Team("Jeroen");


    public static void Init()
    {
        Object soldier = Resources.Load("Prefabs/Units/Soldier");
        Object siegeUnit = Resources.Load("Prefabs/Units/Siege");

        for (int i = 0; i < maxSoldiers; i++)
        {
            soldiers[i] = (GameObject) MonoBehaviour.Instantiate(soldier, new Vector3(0, 0, 0), Quaternion.identity);
            soldiers[i].SetActive(false);
        }
        for (int i = 0; i < maxSiegeUnits; i++)
        {
            siegeUnits[i] = (GameObject)MonoBehaviour.Instantiate(siegeUnit, new Vector3(0, 0, 0), Quaternion.identity);
            siegeUnits[i].SetActive(false);
        }

        base1 = GameObject.Find("Base1").GetComponent<Base>();
        base2 = GameObject.Find("Base2").GetComponent<Base>();
        base1.team = team1;
        base2.team = team2;
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
}
