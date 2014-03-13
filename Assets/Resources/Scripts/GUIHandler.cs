using UnityEngine;
using System.Collections;

public class GUIHandler : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnGUI()
    {
        GUI.contentColor = Color.green;
        GUI.Label(new Rect(400, 25, 100, 25), ObjectPool.team1.name + ": $ " + ObjectPool.team1.currency);
        GUI.Label(new Rect(400, 50, 100, 25), ObjectPool.team2.name + ": $ " + ObjectPool.team2.currency);
    }
}