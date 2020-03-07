using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalTimer : MonoBehaviour
{

    public float startingTime = 60;
    public float currentTime = 0;

    public Text timerText;

    [SerializeField]
    float combo = 1.0f;
    float comboIncrease = 0.02f;
    float comboDecrease = 0.05f;

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

    public void AddTime()
    {
        if (combo < 1.0f)
        {
            combo = 1.0f;
        }

        combo += comboIncrease;
        currentTime *= combo;
        StartCoroutine(scaleTimer());
    }

    public void RemoveTime()
    {
        if (combo > 1.0f)
        {
            combo = 1.0f;
        }
        combo -= comboDecrease;
        currentTime *= combo;
        StartCoroutine(scaleTimer());
    }

    private IEnumerator scaleTimer()
    {
        timerText.fontSize += 10;
        yield return new WaitForSeconds(0.2f);
        timerText.fontSize -= 10;
    }
}
