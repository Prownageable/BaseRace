using UnityEngine;
using System.Collections;

public class Structure : MonoBehaviour
{
    public float dmg = 0f;
    public float attackSpeed = 1.2f;
    public int team = 0;
    public float range = 5f;
    public float maxHp = 5;
    private float curHp;
    public float armor = 3;
    GameObject healthBar;


    private GameObject t;
    private bool inEnemyRange = false;
    private float timer = 0.0f;
    // Use this for initialization
    void Start()
    {
        curHp = maxHp;
        healthBar = GameObject.CreatePrimitive(PrimitiveType.Cube);

        healthBar.renderer.material.color = Color.green;
        healthBar.transform.localScale = new Vector3(2f, 0.5f, 0.5f);
        healthBar.renderer.castShadows = false;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + this.gameObject.renderer.bounds.size.y / 2 + 2, this.gameObject.transform.position.z);
        healthBar.transform.localScale = new Vector3(2f * (curHp / maxHp), 0.5f, 0.5f);

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
        if (target.GetComponent<Unit>())
        {
            target.GetComponent<Unit>().Damage(d);
        }
        else
        {
            print("Geen unit");
        }
    }

    public void Damage(float d)
    {
        float dmgPercentage = (10 - armor) / 10;
        if (dmgPercentage < 0.20f)
        {
            dmgPercentage = 0.20f;
        }
        curHp = curHp - (d * dmgPercentage);
        if (curHp <= 0)
        {
            Destroy(this.gameObject);
            Destroy(healthBar);
        }

        float hpPercentage = (curHp / maxHp);
        if (hpPercentage > 0.25 && hpPercentage < 0.5)
        {
            healthBar.renderer.material.color = Color.yellow;
        }
        if (hpPercentage <= 0.25)
        {
            healthBar.renderer.material.color = Color.red;
        }
    }
}
