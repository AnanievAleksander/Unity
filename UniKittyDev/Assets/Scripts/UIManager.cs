using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] lives;
    public Image livesImageDisplay;
    public GameObject startScreen;
    public GameObject finishScreen;
    public Text scoreText;
    public Text livesCounter;
    public int score;

    public void UpdateLives(int currentLives)
    {
        Debug.Log("Player lives:" + currentLives);
        livesImageDisplay.sprite = lives[currentLives];
    }
    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "Score:" + score;

    }

    public void UpdateLivesCounter(int currentLives)
    {
        livesCounter.text = "x" + currentLives;
    }
    public void HideStartScreen()
    {
        startScreen.SetActive(false);
    }
    public void ShowFinishScreen()
    {
        finishScreen.SetActive(true);
        this.score = -10;
    }

    public void HideFinishScreen()
    {
        finishScreen.SetActive(false);
        
        
    }



    
    
}
