using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [Header("Default Start Time")]
    public static float TimeLeft;

    [Header("GameOver UI Object")]
    public GameObject gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {

        Time.timeScale = 1;

        TimeLeft = 60;
        gameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeLeft > 0)
        {
            TimeLeft -= Time.deltaTime;
            GetComponent<UnityEngine.UI.Text>().text = TimeLeft.ToString();

        } else
        {
            Time.timeScale = 0;
            gameOverCanvas.SetActive(true);
        }

    }
}
