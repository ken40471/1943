using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Missile : MonoBehaviour
{
    public Launch nuke;
    public Transform target;
    private Rigidbody rocket;
    public GameObject rocket_smoke;
    public GameObject missile_explode_particle;
    private float timer_collider = 0.3f;
   // public bool isPlayer;

    public float turnSpeed;
    public float flySpeed;

    private Transform rocketLocalTransform;
    // Start is called before the first frame update
    void Start()
    {

        rocketLocalTransform = GetComponent<Transform>();
        rocket = this.GetComponent<Rigidbody>();

        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer_collider -= 1 * Time.deltaTime;
        if(timer_collider <= 0)
        {
            timer_collider = 0;
            gameObject.GetComponent<CapsuleCollider>().enabled = true;
        }
        launchMissile();       
    }

    public void launchMissile()
    {

        rocket.velocity = rocketLocalTransform.forward * flySpeed;
        var rocketTargetRot = Quaternion.LookRotation(target.position - rocketLocalTransform.position);
        rocket.MoveRotation(Quaternion.RotateTowards(rocketLocalTransform.rotation, rocketTargetRot, turnSpeed));

    }
    private void OnCollisionEnter(Collision collision)
    {
        rocket_smoke.transform.parent = null;
        Instantiate(missile_explode_particle, this.transform.position, this.transform.rotation);
        
        Destroy(gameObject);
    }
}
