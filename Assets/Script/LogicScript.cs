using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime =  10f;

    void Start()
    {
        currentTime = startingTime;
    }
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
    }
    public void restartGame()

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}

