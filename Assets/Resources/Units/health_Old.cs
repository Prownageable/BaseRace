using UnityEngine;
using System.Collections;

public class health_Old : MonoBehaviour
{
    public float hp = 5;
    public float armor = 3;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(float d)
    {
        float dmgPercentage = (10 - armor) / 10;
        if (dmgPercentage < 0.20f)
        {
            dmgPercentage = 0.20f;
        }
        hp = hp - (d * dmgPercentage);
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
