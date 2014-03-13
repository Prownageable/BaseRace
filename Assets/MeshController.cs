using UnityEngine;
using System.Collections;

public class MeshController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnMouseEnter()
    {
        print("Mouse entering!");
    }

    void OnMouseExit()
    {
        print("Mouse leaving!");
    }

    void OnMouseDown()
    {
        print("Click!");
    }
}
