using UnityEngine;
using System.Collections;

public class Structure : MonoBehaviour
{
    public Team team;

    public float maxHp = 5;
    public float armor = 3;

    private GameObject healthBar;

    private float curHp;

    // Use this for initialization
    internal void Start()
    {
        curHp = maxHp;

        healthBar = transform.GetChild(1).gameObject;
        healthBar.transform.localScale = new Vector3(2f, 0.5f, 0.5f);
        healthBar.renderer.material.color = Color.green;
        healthBar.renderer.castShadows = false;
        healthBar.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + this.gameObject.renderer.bounds.size.y / 2 + 2, this.gameObject.transform.position.z);
        healthBar.transform.localScale = new Vector3(2f * (curHp / maxHp), 0.5f, 0.5f);

    }

    // Update is called once per frame
    internal void Update()
    {
        healthBar.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 20, this.gameObject.transform.position.z);
        healthBar.transform.localScale = new Vector3(2f * (curHp / maxHp), 0.5f, 0.5f);
    }

    public void ReceiveDamage(float d)
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
