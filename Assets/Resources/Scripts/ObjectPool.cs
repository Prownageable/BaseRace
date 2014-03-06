using UnityEngine;
using System.Collections;

public static class ObjectPool
{
    public const int maxSoldiers = 50;
    public const int maxSiegeUnits = 25;

    public static GameObject[] soldiers = new GameObject[maxSoldiers];
    public static GameObject[] siegeUnits = new GameObject[maxSoldiers];


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
    }

    public static void DeleteGameObject(GameObject go)
    {
        go.SetActive(false);
    }
}
