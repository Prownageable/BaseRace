using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour
{
    public GameObject[] unit;

    public void Spawn(int u)
    {
        string tag = this.gameObject.tag;
        unit[u].tag = tag;
        if (tag.Equals("friendly"))
        {
            //Instantiate (unit [u], new Vector3 (this.transform.position.x + this.gameObject.renderer.bounds.size.x / 2 + unit [u].gameObject.renderer.bounds.size.x / 2, unit [u].gameObject.renderer.bounds.size.y / 2, this.transform.position.z), Quaternion.identity);
            Instantiate(unit[u], new Vector3(this.transform.position.x, unit[u].gameObject.renderer.bounds.size.y / 2, this.transform.position.z), Quaternion.identity);
        }
        else
        {
            //Instantiate (unit [u], new Vector3 (this.transform.position.x - this.gameObject.renderer.bounds.size.x / 2 - unit [u].gameObject.renderer.bounds.size.x / 2, unit [u].gameObject.renderer.bounds.size.y / 2, this.transform.position.z), Quaternion.identity);
            Instantiate(unit[u], new Vector3(this.transform.position.x, unit[u].gameObject.renderer.bounds.size.y / 2, this.transform.position.z), Quaternion.identity);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}