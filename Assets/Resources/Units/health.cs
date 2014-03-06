using UnityEngine;
using System.Collections;

public class health : MonoBehaviour
{
    public float maxHp = 5;
    private float curHp;
    public float armor = 3;
    GameObject healthBar;

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
