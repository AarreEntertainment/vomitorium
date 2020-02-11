using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletController : MonoBehaviour
{
    public ParticleSystem Explosion;
    public string AxisName;
    public float BulletFiringTime;
    public GameObject bullet;
    public LayerMask hitLayers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void InstantiateBullet()
    {
        bulletTime = BulletFiringTime;
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = transform.position;
        newBullet.transform.forward = transform.forward;
        newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * 100, ForceMode.Impulse);

    }
    float bulletTime=0;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (bulletTime > 0)
            bulletTime -= Time.deltaTime;
        if (Input.GetAxis(AxisName) > 0.5f)
        {
            if (bulletTime <= 0)
                InstantiateBullet();
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, hitLayers))
            {
                
                Explosion.transform.position = hit.point;
                Explosion.Play();
            }
        }
    }
}
