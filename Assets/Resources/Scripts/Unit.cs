﻿using UnityEngine;
using System.Collections;
using System;

public class Unit : MonoBehaviour
{
    public float dmg = 5f;
    public float attackSpeed = 1.2f;
    public float speed = 5f;
    public float range = 5f;
    public float maxHp = 5;
    public float armor = 3;
    public float spawnTime = 2;

    public float cost = 5f;

    public Team team;

    private GameObject target;
    private GameObject healthBar;

    public bool enemyInRange = false;
    public float timer = 0.0f;
    public float curHp;

    private bool isQueued;

    // Use this for initialization
    internal void Start()
    {
        timer = attackSpeed;
        curHp = maxHp;
        enemyInRange = false;
        target = null;

        //float scalePercentage = (1 * this.transform.localScale.x);

        healthBar = transform.GetChild(0).gameObject;
        healthBar.transform.localScale = new Vector3(2f, 0.5f, 0.5f);
        healthBar.renderer.material.color = Color.green;
        healthBar.renderer.castShadows = false;        
        healthBar.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + this.gameObject.renderer.bounds.size.y / 2 + 2, this.gameObject.transform.position.z);
        healthBar.transform.localScale = new Vector3(2f * (curHp / maxHp), 0.5f, 0.5f) / this.transform.localScale.x;
    }

    // Update is called once per frame
    internal void Update()
    {
        if (target != null)
        {
            if (target.activeSelf)
            {
                if (enemyInRange)
                {
                    timer += Time.deltaTime;
                    if (timer > attackSpeed)
                    {
                        DealDamage(target, dmg);
                        if (!target.activeSelf)
                        {
                            target = null;
                            enemyInRange = false;
                        }
                        timer = 0.0f;
                    }
                }
                else
                {
                    throw new Exception("Shit broke man!");
                }
            }
            else
            {
                Move();
                FindEnemy();
            }
        }
        else
        {
            Move();
            FindEnemy();
        }
        if (transform.position.y <= -10)
        {
            gameObject.SetActive(false);
        }
    }

    private void FindEnemy()
    {
        GameObject[] enemySoldiers = ObjectPool.getEnemySoldiers(team);
        for (int i = 0; i < ObjectPool.maxSoldiers; i++)
        {
            if (enemySoldiers[i].activeSelf && enemySoldiers[i].GetComponent<Unit>().team != team)
            {
                // Found enemy soldier
                if (Vector3.Distance(this.transform.position, enemySoldiers[i].transform.position) <= range)
                {
                    // Enemy in range
                    target = enemySoldiers[i];
                    enemyInRange = true;
                    return;
                }
            }
        }
        GameObject[] enemySiegeUnits = ObjectPool.getEnemySiegeUnits(team);
        for (int i = 0; i < ObjectPool.maxSiegeUnits; i++)
        {
            if (enemySiegeUnits[i].activeSelf && enemySiegeUnits[i].GetComponent<Unit>().team != team)
            {
                // Found enemy siege unit
                if (Vector3.Distance(this.transform.position, enemySiegeUnits[i].transform.position) <= range)
                {
                    // Enemy in range
                    target = enemySiegeUnits[i];
                    enemyInRange = true;
                    return;
                }
            }
        }
        if (this.team == ObjectPool.base1.team)
        {
            if (Vector3.Distance(this.transform.position, ObjectPool.base2.transform.position) <= range)
            {
                // Enemy in range
                target = ObjectPool.base2.gameObject;
                enemyInRange = true;
                    return;
            }
        }
        else
        {
            if (Vector3.Distance(this.transform.position, ObjectPool.base1.transform.position) <= range)
            {
                // Enemy in range
                target = ObjectPool.base1.gameObject;
                enemyInRange = true;
                    return;
            }
        }        
    }

    private void DealDamage(GameObject target, float d)
    {
        audio.Play ();
        if (target.GetComponent<Unit>())
        {
            target.GetComponent<Unit>().ReceiveDamage(d);
        }
        else if(target.GetComponent<Structure>())
        {
            target.GetComponent<Structure>().ReceiveDamage(d);
        }
        else
        {
            throw new Exception("Geen unit");
        }
    }

    private void Move()
    {
        if (team.name == "Rik")
        {
            //transform.position -= new Vector3(1, 0, 0) * Time.deltaTime * speed;
            transform.position = Vector3.MoveTowards(transform.position, ObjectPool.getEnemyTeam(team).base_building.transform.position, Time.deltaTime * speed);
        }
        else
        {
            //transform.position += new Vector3(1, 0, 0) * Time.deltaTime * speed;
            transform.position = Vector3.MoveTowards(transform.position, ObjectPool.getEnemyTeam(team).base_building.transform.position, Time.deltaTime * speed);
        }
    }

    public void ReceiveDamage(float d)
    {
        float dmgPercentage = (10 - armor) / 10;
        if (dmgPercentage < 0.20f)
        {
            dmgPercentage = 0.20f;
        }
        curHp = curHp - (d * dmgPercentage);
        // Unit dies! R.I.P.
        if (curHp <= 0)
        {
            ObjectPool.getEnemyTeam(team).AddCurrency(cost * 1.25f);
            gameObject.SetActive(false);
            return;
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

        healthBar.transform.localScale = new Vector3(2f * (curHp / maxHp), 0.5f, 0.5f) / this.transform.localScale.x;
    }

    internal void AddToQueue()
    {
        isQueued = true;
    }

    internal void RemoveFromQueue()
    {
        isQueued = false;
    }

    internal bool IsQueued()
    {
        return isQueued;
    }
}