using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Launch : MonoBehaviour
{

    public Player_Health Jet_mesh;
    [Header("Missile Launch Setup")]
    public GameObject missiles;
    public GameObject missileRightWing;
    public GameObject missileLeftWing;
    public Transform launch_pos_right;
    public Transform launch_pos_left;
    public bool is_launched_right;
    public Transform _object;

    [Header("Sound Setup")]
    public AudioSource missile_launch;
    public AudioSource missile_Collision;
    public AudioSource explosion;


    [Header("Ammo Setup")]
    public int ammo;
    public TextMeshProUGUI ammoUI;


    private void Start()
    {
        is_launched_right = false;
       
        ammoUI.text = ammo.ToString();
    }

    private void LateUpdate()
    {
        if (ammo > 0)
        {
            if (Jet_mesh.reloadRight <= 0)
            {
                missileRightWing.SetActive(true);
            }
            else
            {
                missileRightWing.SetActive(false);
            }
            if (Jet_mesh.reloadLeft <= 0)
            {
                missileLeftWing.SetActive(true);
            }
            else
            {
                missileLeftWing.SetActive(false);
            }
            if (Jet_mesh.health <= 0)
            {
                explosion.Play();
            }
        }
        else
        {
            missileRightWing.SetActive(false);
            missileLeftWing.SetActive(false);
        }
    }
    public void launchMissile()
    {
        if (ammo > 0)
        {
            var comp = this.GetComponent<Launch>();
            missiles.GetComponent<Missile>().nuke = comp;
            missiles.GetComponent<Missile>().target = null;
            missiles.GetComponent<Missile>().target = _object;

            if(is_launched_right == false)
            {
                if(Jet_mesh.reloadRight <= 0)
                {
                    //launching from right wings
                    Instantiate(missiles, launch_pos_right.position, launch_pos_right.rotation);
                    Jet_mesh.reloadRight = 3;

                    ammo -= 1;
                    ammoUI.text = ammo.ToString();

                    missile_launch.Play();


                }               
            }

            if (is_launched_right == true)
            {
                if(Jet_mesh.reloadLeft <= 0)
                {
                    //launching from left wings
                    Instantiate(missiles, launch_pos_left.position, launch_pos_left.rotation);
                    Jet_mesh.reloadLeft = 3;

                    ammo -= 1;
                    ammoUI.text = ammo.ToString();

                    missile_launch.Play();

                }
               
            }

            is_launched_right = !is_launched_right;
        }
        else
        {
            ammoUI.text = "no ammo! land on AirCraft Carrier to refill";
        }


    }

}
