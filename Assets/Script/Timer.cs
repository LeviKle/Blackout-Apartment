using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    

    private float timeDuration =60f + 30f;
    public float timer;

    [SerializeField]
    private TextMeshProUGUI firstMinute;
    [SerializeField]
    private TextMeshProUGUI secondMinute;
    [SerializeField]
    private TextMeshProUGUI separator;
    [SerializeField]
    private TextMeshProUGUI firstSecond;
    [SerializeField]
    private TextMeshProUGUI secondSecond;
    void Start(){
        ResetTimer();
    }

    void Update(){
        // print(timer);
        if (timer > 0){
            timer -= Time.deltaTime;
            UpdateTimerDisplay(timer);
        }
        else {
            Flash();
        }
    }
    private void ResetTimer(){
        timer = timeDuration;
    }

    private void UpdateTimerDisplay(float time){
        float minutes = Mathf.FloorToInt(time/60);
        float seconds = Mathf.FloorToInt(time%60);

        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();
    }


private void Flash(){
    if(timer !=0){
        timer=0;
        UpdateTimerDisplay(timer);
    }
        
}
}