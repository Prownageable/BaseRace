using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
    public float dmg = 5f;
    public float attackSpeed = 1.2f;
    public int team = 0;
    public float speed = 5f;
    public float range = 5f;


    private GameObject t;
    private bool inEnemyRange = false;
    private float timer = 0.0f;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (inEnemyRange == true && t != null)
        {
            //this.gameObject.GetComponent<move>().speed = 0;
            //speed = 0;
            if (timer == 0.0f)
            {
                Debug.Log("shoot");
                dealDamage(t, dmg);
            }
            timer += Time.deltaTime;
            if (timer > attackSpeed)
            {
                timer = 0.0f;
            }
        }
        else
        {
            Move();
            //speed = 5;
            //this.gameObject.GetComponent<move>().speed = 5;
            timer = 0.0f;
        }
    }

    void OnTriggerStay(Collider c)
    {
        if (!t)
        {
            if (c.GetType() != typeof(SphereCollider))
            {
                if (this.gameObject.tag == "enemy")
                {
                    if (c.gameObject.tag == "friendly")
                    {
                        inEnemyRange = true;
                        t = c.gameObject;
                        print("friendly in range");
                    }
                }
                else
                {
                    if (c.gameObject.tag == "enemy")
                    {
                        inEnemyRange = true;
                        t = c.gameObject;
                        print("enemy in range ");
                    }
                }
            }
        }
    }


    void OnTriggerExit(Collider c)
    {
        t = null;
    }

    private void FindEnemy()
    {

    }

    private void dealDamage(GameObject target, float d)
    {
        //audio.Play ();
        target.GetComponent<health>().Damage(d);
    }

    private void Move()
    {
        if (this.gameObject.tag == "enemy")
        {
            transform.position -= new Vector3(1, 0, 0) * Time.deltaTime * speed;
        }
        else if (this.gameObject.tag == "friendly")
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * speed;
        }
    }
}
