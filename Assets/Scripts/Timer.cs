using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
public TextMeshProUGUI timerText;
private int timeint;
private float timesecs = 61;

void Update(){
timeint = (int)timesecs;
timerText.text = timeint.ToString();
timer();
if(timesecs == 0)
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
}

void timer()
    {

        if (timesecs > 0)
        {
            timesecs -= Time.deltaTime;
        }

    }

}