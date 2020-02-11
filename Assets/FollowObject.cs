using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform Source;
    public Rigidbody RotatingBody;
    public Rigidbody MovingBody;
    public float MoveX;
    public float MoveY;
    public float TiltZ;
    public float TiltY;
    public float velDiff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float lastVelocity;
    float thrust;
    float GetThrust(float val)
    {
        float ret = thrust;
        thrust -= Time.deltaTime * val;
        return ret;
    }
    public AudioSource crash;
    private void LateUpdate()
    {
        transform.position = Source.position;
        velDiff = Mathf.Abs(MovingBody.velocity.normalized.magnitude - lastVelocity);
        lastVelocity = MovingBody.velocity.normalized.magnitude;
    }

    public Animator shakeAnim;
    public void Shake()
    {
        shakeAnim.SetTrigger("ShakeUp");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        

#if UNITY_EDITOR
        MoveX = Input.GetAxis("Horizontal");
        MoveY = Input.GetAxis("Vertical");
#elif UNITY_ANDROID
        MoveX = Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal");
        MoveY = Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical");
        TiltY = Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickHorizontal");
        TiltZ = Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical");
#endif
        if (thrust < 2) thrust += Time.deltaTime;

        MovingBody.AddForce((RotatingBody.transform.right * MoveX + RotatingBody.transform.up * MoveY)*5, ForceMode.VelocityChange);
        
        if (Mathf.Abs(MoveX)<0.2f)
        {
            MovingBody.AddForce(new Vector3( -MovingBody.velocity.x/6,0,0), ForceMode.Impulse);
        }
        if (Mathf.Abs(MoveY) < 0.2f)
        {
            MovingBody.AddForce(new Vector3(0, 0,-MovingBody.velocity.z / 6), ForceMode.Impulse);
        }
    }
}
