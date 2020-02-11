using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public Transform Player;
    bool launched = false;
    public void launchAtPlayer() {
        transform.LookAt(Player.position + Player.forward*2);
        GetComponent<Rigidbody>().AddForce(transform.forward * 80, ForceMode.Impulse);
    }

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void GetHit(BulletImpact impact)
    {
        health -= impact.BulletStrength;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {

        GetComponent<Animator>().SetTrigger("Die");
    }

    public void trash()
    {

        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (Player == null)
            return;
        if(Vector3.Distance(transform.position, Player.position) < 100 && !launched)
        {
            launched = true;
            launchAtPlayer();
        }
    }
}
