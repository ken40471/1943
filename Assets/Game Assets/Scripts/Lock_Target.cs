using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lock_Target : MonoBehaviour
{

    public Launch assign;
    public bool locked = false;
    public GameObject healthBar_show;
    public Slider healthBar;
    [SerializeField]
    private float maxValue;
    public GameObject targetIcon;
    public AudioSource lock_sound;
    public GameObject explosion_particle;

    private void Start()
    {
        healthBar.maxValue = maxValue;
        healthBar_show.SetActive(false);
        healthBar.value = maxValue;

    }
    private void OnMouseDown()
    {
        Debug.Log("target locked");
        healthBar_show.SetActive(true);
        assign = GameObject.Find("EventSystem").GetComponent<Launch>();
        assign._object = this.transform;
        targetIcon.SetActive(true);
        lock_sound.Play();
        
    }

    private void FixedUpdate()
    {
        if (healthBar.value <= 0)
        {
            Instantiate(explosion_particle, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
            assign.explosion.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "missile")
        {
            Debug.Log("Ship is hit by Missile");
            healthBar.value -= 5;
            assign.missile_Collision.Play();
        }
    }
}
