using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerLogic : MonoBehaviour
{

    public float startTime = 60;
    public float currentTime;
    public bool isTimerRunning = false;

    public TextMeshProUGUI timerText;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;

    }

    // Update is called once per frame
    void Update()
    {

        timerText.text = currentTime.ToString().Substring(0,2);

        if (isTimerRunning == true && currentTime > 0) 
        {
            currentTime -= Time.deltaTime;
        }

        if (currentTime <= 0) 
        {
            currentTime = 0;

            if (FindAnyObjectByType<CharacterMovement>().CarrotCollect == 5)
            {
                Invoke("DelayWin", 2f);
  
            }
            else 
            {
                Invoke("DelayLose", 2f);
            }


        }        
    }

    public void DelayWin()
    {
     //   Invoke("DelayMain", 2f);
        SceneManager.LoadScene("Good Job");
    }

    public void DelayLose()
    {
      //  Invoke("DelayMain", 2f);
        SceneManager.LoadScene("Try Again");
    }

    public void DelayMain()
    {
        SceneManager.LoadScene("TitleScreen");
    }

}
