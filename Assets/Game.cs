using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Timer script;
    public GameOverScreen GameOver;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (script.timer == 0)
        {
            GameOver.Setup();
        }
    }
}
