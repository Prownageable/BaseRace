using UnityEngine;
using System.Collections;

public class ResearchFacility : Structure
{
	public GameObject[] enemy;
	
	
	public void Spawn (int e){
		enemy [e].tag = "enemy";
		Instantiate (enemy[e], new Vector3(this.transform.position.x, enemy[e].gameObject.renderer.bounds.size.y/2, this.transform.position.z), Quaternion.identity);
		
	}                    
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
