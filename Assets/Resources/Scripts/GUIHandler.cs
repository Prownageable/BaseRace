using UnityEngine;
using System.Collections;

public class GUIHandler : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        ObjectPool.Init();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnGUI()
    {
        GUI.contentColor = Color.white;
        //GUI.Label(new Rect(400, 25, 100, 25), ObjectPool.team1.name + ": $ " + ObjectPool.team1.currency);
        //GUI.Label(new Rect(400, 50, 100, 25), ObjectPool.team2.name + ": $ " + ObjectPool.team2.currency);

        // Team 1
        GUI.Box(new Rect(Screen.width - 110, Screen.height - 100, 100, 90), ObjectPool.team1.name + " : $" + ObjectPool.team1.currency);

        if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 70, 80, 20), "Soldier (K)") | Input.GetKeyDown(KeyCode.K))
        {
            ObjectPool.team1.base_building.GetComponent<Base>().SpawnSoldier();
        }

        if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 40, 80, 20), "Sieger (L)") | Input.GetKeyDown(KeyCode.L))
        {
            ObjectPool.team1.base_building.GetComponent<Base>().SpawnSiege();
        }

        // Team 2
        GUI.Box(new Rect(10, Screen.height - 100, 100, 90), ObjectPool.team2.name + " : $" + ObjectPool.team2.currency);

        if (GUI.Button(new Rect(20, Screen.height - 70, 80, 20), "Soldier (A)") | Input.GetKeyDown(KeyCode.A))
        {
            ObjectPool.team2.base_building.GetComponent<Base>().SpawnSoldier();
        }

        if (GUI.Button(new Rect(20, Screen.height - 40, 80, 20), "Sieger (S)") | Input.GetKeyDown(KeyCode.S))
        {
            ObjectPool.team2.base_building.GetComponent<Base>().SpawnSiege();
        }
        //Verandering
    }
}