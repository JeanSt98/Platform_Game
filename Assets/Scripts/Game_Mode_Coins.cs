using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Game_Manager manager;
    public GameObject[] cherries;
    public Text coinText;

    // Update is called once per frame
    void Update()
    {
        cherries = GameObject.FindGameObjectsWithTag("Cherry");
        if(cherries.Length == 0)
        {
            manager.FinishLevel();
        }
        
        //Update UI
        coinText.text = "x" + cherries.Length.ToString();
    }
}
