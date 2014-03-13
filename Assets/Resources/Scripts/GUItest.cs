using UnityEngine;
using System.Collections;

public class GUItest : MonoBehaviour
{

    void Start()
    {
        ObjectPool.Init();
    }

    void OnGUI()
    {
        //if (GUI.Button(new Rect(10, 10, 100, 60), "Soldier"))
        //{
        //    print("Spawnsodlier");
        //    ObjectPool.base1.SpawnSoldier();
        //}

        //if (GUI.Button(new Rect(110, 10, 100, 60), "Enemy soldier"))
        //{
        //    print("Spawnsodlier");
        //    ObjectPool.base2.SpawnSoldier();
        //}

        //if (GUI.Button(new Rect(10, 70, 100, 60), "Siege"))
        //{
        //    print("Spawn siege");
        //    ObjectPool.base1.SpawnSiege();
        //}

        //if (GUI.Button(new Rect(110, 70, 100, 60), "Enemy siege"))
        //{
        //    print("Spawn siege");
        //    ObjectPool.base2.SpawnSiege();
        //}
    }

    void Update()
    {
    }
}

