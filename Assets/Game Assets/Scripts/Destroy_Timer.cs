using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Timer : MonoBehaviour
{

    public float timer;
    public float countdown;
    public bool icon;
    // Start is called before the first frame update
    private void Start()
    {
        timer = countdown;
    }
    public void Destroy()
    {
        countdown -= 1 * Time.deltaTime;
        if (countdown<= 0)
        {
            if(icon == true)
            {
                gameObject.SetActive(false);
                
            }
            else
            {
                Destroy(gameObject);
            }
            countdown = timer;
        }
    }

    void FixedUpdate()
    {
        Destroy();
    }
}
