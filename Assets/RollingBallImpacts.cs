using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBallImpacts : MonoBehaviour
{
    public FollowObject eyeObject;
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.relativeVelocity.magnitude > 10)
        {
            GetComponent<AudioSource>().volume = collision.relativeVelocity.magnitude / 30;
            GetComponent<AudioSource>().Play();

        }
        if (collision.collider.tag == "GiveDamage")
        {
            eyeObject.Shake();
            if (collision.collider.GetComponent<Enemy>() != null)
            {
                collision.collider.GetComponent<Enemy>().Die();
            }
        }
            
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
