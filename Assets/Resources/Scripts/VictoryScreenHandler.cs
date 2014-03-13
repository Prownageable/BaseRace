using UnityEngine;
using System.Collections;

public class VictoryScreenHandler : MonoBehaviour {
    public static Team winningTeam = null;

	// Use this for initialization
	void Start () {
        GUIText text = new GUIText();
        text.fontSize = 70;
        text.alignment = TextAlignment.Center;
        text.anchor = TextAnchor.MiddleCenter;
        text.text = winningTeam.name + " has won!";
	}
	
	// Update is called once per frame
	void Update () {

	}
}
