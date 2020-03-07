using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalTimer : MonoBehaviour
{

    public float startingTime = 60;
    public float currentTime = 0;

    public Text timerText;

    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timerText.text = currentTime.ToString("0");

        if (currentTime > 10f)
        {
            timerText.color = Color.white;
        }
        else {
            timerText.color = Color.red;

            if (currentTime <= 0f)
            {
                // Game Over
                Debug.Log("Game Over");
            }
        }

    }

    public void AddTime(float time)
    {
        currentTime += time;
    }

    public void RemoveTime(float time)
    {
        currentTime -= time;
    }
}
