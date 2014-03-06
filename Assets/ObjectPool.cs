using UnityEngine;
using System.Collections;

public static class ObjectPool
{
    public const int maxSoldiers = 50;
    public const int maxSiegeUnits = 25;

    public static GameObject[] soldiers = new GameObject[maxSoldiers];
    public static GameObject[] siegeUnits = new GameObject[maxSiegeUnits];

    public static void Init()
    {
        Object soldier = Resources.Load("Units/Soldier/Soldier");
        Object siegeUnit = Resources.Load("Units/Siege/Siege");

        for (int i = 0; i < maxSoldiers; i++)
        {
            soldiers[i] = (GameObject) MonoBehaviour.Instantiate(soldier, new Vector3(0, 0, 0), Quaternion.identity);
            soldiers[i].SetActive(false);
        }
        for (int i = 0; i < maxSiegeUnits; i++)
        {
            siegeUnits[i] = (GameObject) MonoBehaviour.Instantiate(siegeUnit, new Vector3(0, 0, 0), Quaternion.identity);
            siegeUnits[i].SetActive(false);
        }
    }

    public static GameObject GetSoldier()
    {
        for (int i = 0; i < maxSoldiers; i++)
        {
            if (soldiers[i].activeSelf)
                return soldiers[i];
        }
        return null;
    }

    public static GameObject GetSiegeUnit()
    {
        for (int i = 0; i < maxSiegeUnits; i++)
        {
            if (siegeUnits[i].activeSelf)
                return siegeUnits[i];
        }
        return null;
    }

    public static void DeleteGameObject(GameObject go)
    {
        go.SetActive(false);
    }
}
