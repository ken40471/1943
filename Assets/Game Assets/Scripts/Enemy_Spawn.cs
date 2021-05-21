using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy_Spawn : MonoBehaviour
{

    public Transform spawnPoint;
    public float countdown;
    public float reset;
    public GameObject enemies;
    public GameObject[] enemy_objects;
    public int numberOfEnemies;
    public TextMeshProUGUI numberOfEnemiesUI;
  //  public int points;
   // public TextMeshProUGUI pointsUI;
    // Start is called before the first frame update
    void Start()
    {

     //   pointsUI.text = ("points: " + points);
        reset = countdown;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemy_objects = GameObject.FindGameObjectsWithTag("enemy");
        numberOfEnemies = enemy_objects.Length;
        numberOfEnemiesUI.text = ("Enemies: " + numberOfEnemies.ToString());

        


        if(numberOfEnemies <= 5)
        {
            countdown -= 1 * Time.deltaTime;

            if (countdown <= 0)
            {
                Instantiate(enemies, spawnPoint.position, spawnPoint.rotation);
                countdown = reset;
            }
        }

    }
}
