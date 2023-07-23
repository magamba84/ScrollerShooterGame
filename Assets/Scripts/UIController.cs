using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject HPBar;
    public Text HPText;

    public GameObject endGameBar;
    public Text endGameText;
    public GameObject RestartButton;

    public void ShowHP(int hp)
    {
        endGameBar.SetActive(false);
        RestartButton.SetActive(false);
        HPBar.SetActive(true);
        HPText.text = "HP: "+hp.ToString();
    }
    public void HideHP()
    {
        HPBar.SetActive(false);
    }

    public void ShowEndGame(bool win) 
    {
        HideHP();
        endGameBar.SetActive(true);
        endGameText.text = win ? "Victory!" : "Defeat!";
        RestartButton.SetActive(true);
    }
}
