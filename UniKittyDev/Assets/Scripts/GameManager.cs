using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _unikitty;
    public bool gameOver = true;
    private UIManager _uiManager;
    //if game over is true
    // if space key pressed
    // Game over is false
    // hide title screen
    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        
        
       
    }

    private void Update()
    {
        if (gameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _uiManager.HideFinishScreen();
                



                Instantiate(_unikitty, Vector3.zero, Quaternion.identity);
                gameOver = false;
                _uiManager.HideStartScreen();


            }
        }
        
       

        
    }
}
