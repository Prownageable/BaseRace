using UnityEngine;
using System.Collections;

public class GUItest : MonoBehaviour
{
    public GameObject spawner;
    public GameObject pre_spawner;
    private spawner s;
    private spawner se;

    void Start()
    {
        s  = GameObject.Find("Base1").GetComponent<spawner>();
        se = GameObject.Find("Base2").GetComponent<spawner>();

        ObjectPool.Init();
        GameObject g;
        if ((g = ObjectPool.GetSoldier()) != null)
        {
            g.transform.position = new Vector3(0, 10, 0);
            g.SetActive(true);
        }
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 60), "Soldier"))
        {
            s.Spawn(0);
        }

        if (GUI.Button(new Rect(110, 10, 100, 60), "Enemy soldier"))
        {
            se.Spawn(0);
        }

        if (GUI.Button(new Rect(10, 70, 100, 60), "Siege"))
        {
            s.Spawn(1);
        }

        if (GUI.Button(new Rect(110, 70, 100, 60), "Enemy siege"))
        {
            se.Spawn(1);
        }
    }

    void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
        }
    }
}

