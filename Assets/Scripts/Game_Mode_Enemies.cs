using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Mode_Enemies : MonoBehaviour
{
    public Game_Manager manager;
    public GameObject[] enemies;
    public Text enemyText;

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            manager.FinishLevel();
        }

        //Update UI
        enemyText.text = "x" + enemies.Length.ToString();
    }
}
