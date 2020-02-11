using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpact : MonoBehaviour
{
    public float BulletStrength;

    private void Awake()
    {
        StartCoroutine(SelfDestruct());
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Enemy>()!=null)
        {
            collision.collider.GetComponent<Enemy>().GetHit(this);
        }
        Destroy(gameObject);
    }
    
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
       // GetComponent<Rigidbody>().AddForce(100 * transform.forward, ForceMode.VelocityChange);
    }
}
