using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI status;
    public PlayerController playerController;

    public void setup(bool alive)
    {
        gameObject.SetActive(true);

        switch (alive){
            case true:
                status.text = "You Win!";
                break;
            case false:
                status.text = "You Lose!";
                break;
                
        }


    }

    public void RestartButton()
    {
        gameObject.SetActive(false);
        playerController.changeHealth(playerController.health);
    }
}
