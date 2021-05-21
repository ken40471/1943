using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icons : MonoBehaviour
{
    private Transform player;
    


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.LookAt(player);
    }
}
