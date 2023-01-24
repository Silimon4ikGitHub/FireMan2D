using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour


{
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Wizzard.healthSend <= 0)
        {
            RestartGame();
        }
    }
    private void RestartGame()
    {
        
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        

    }
}
