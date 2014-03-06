using UnityEngine;
using System.Collections;

public class GUItest : MonoBehaviour
{
    private Base base1;
    private Base base2;

    void Start()
    {
        base1 = GameObject.Find("Base1").GetComponent<Base>();
        base2 = GameObject.Find("Base2").GetComponent<Base>();
        base1.team = new Team("Rik");
        base2.team = new Team("Jeroen");

        ObjectPool.Init();
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 60), "Soldier"))
        {
            print("Spawnsodlier");
            base1.SpawnSoldier();
        }

        if (GUI.Button(new Rect(110, 10, 100, 60), "Enemy soldier"))
        {
            print("Spawnsodlier");
            base2.SpawnSoldier();
        }

        if (GUI.Button(new Rect(10, 70, 100, 60), "Siege"))
        {
            print("Spawn siege");
            base1.SpawnSiege();
        }

        if (GUI.Button(new Rect(110, 70, 100, 60), "Enemy siege"))
        {
            print("Spawn siege");
            base2.SpawnSiege();
        }
    }

    void Update()
    {
    }
}

