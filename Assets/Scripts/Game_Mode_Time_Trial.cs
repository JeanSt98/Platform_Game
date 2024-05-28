using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Mode_Time_Trial : MonoBehaviour
{
    public Game_Manager manager;
    public float levelTimer = 300f;
    public Text timeText;

    // Update is called once per frame
    void Update()
    {
        if (levelTimer > 0)
        {
            levelTimer = levelTimer - Time.deltaTime;
        }
        else
        {
            if(manager.isGameOver == false)
            {
                manager.isGameOver = true;
                manager.player.Die();
            }
        }

        //Update UI
        timeText.text = "Time:" + levelTimer.ToString("F1");
    }
}
