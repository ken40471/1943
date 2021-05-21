using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{

    public float health;
    public float maxHealth;
    public Slider playerBar;
    public GameObject exposion_particle;
    public GameObject warningMessage;

    public float reloadRight;
    public float reloadLeft;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        playerBar.maxValue = maxHealth;
        playerBar.value = playerBar.maxValue;

    }

    private void FixedUpdate()
    {
        playerBar.value = health;

        if (health <= 0)
        {
            health = 0;
            Instantiate(exposion_particle, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
        }
        reloadRight -= 1 * Time.deltaTime;
        if(reloadRight <= 0)
        {
            reloadRight = 0;
        }
        reloadLeft -= 1 * Time.deltaTime;
        if (reloadLeft <= 0)
        {
            reloadLeft = 0;
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Water" || collision.gameObject.tag == "enemy")
        {
            print("hit water or enemy ship");
            health -= 80;
            playerBar.value = health;
        }
        if(collision.gameObject.tag == "missile")
        {
            print("Missile hit");
            health -= 15;
            playerBar.value = health;
            Destroy(collision.gameObject);
            GameObject.Find("EventSystem").GetComponent<Launch>().missile_Collision.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        

        if (other.tag == "BattleZone")
        {
            warningMessage.SetActive(true);
        }
    }
}
