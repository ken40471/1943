using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Carrier_Health : MonoBehaviour
{

    public float CarrierHealth;
    public float CarrierMaxhealth;
    public Slider CarrierBar;
    public GameObject blastParticle;
    // Start is called before the first frame update
    void Start()
    {
        CarrierHealth = CarrierMaxhealth;
        CarrierBar.maxValue = CarrierHealth;
        CarrierBar.value = CarrierBar.maxValue;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if(CarrierHealth <= 1)
        {
            Instantiate(blastParticle, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "missile")
        {
            print("Carrier is being hit");
            CarrierHealth -= 1;
            CarrierBar.value = CarrierHealth;
            Destroy(collision.gameObject);
        }
    }
}
