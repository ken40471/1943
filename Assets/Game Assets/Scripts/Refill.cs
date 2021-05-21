using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refill : MonoBehaviour
{
    public Player_Health player;
    public Launch refill;
    public float time = 3;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            time -= 1 * Time.deltaTime;
            print("refilling..,");
            refill.ammoUI.text = "Refilling...";
            if (time <= 0)
            {
                refill.ammo += 1;
                refill.ammoUI.text = refill.ammo.ToString();
                player.health +=1 ;
                player.playerBar.value = player.health;
            }
            if(refill.ammo > 99)
            {
                refill.ammo = 99;
            }
            if(player.health >= player.maxHealth)
            {
                player.health = player.maxHealth;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            time = 3;
        }

    }
}
