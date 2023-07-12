using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndCanvas : MonoBehaviour
{
    [SerializeField] private Text theBestText;
    [SerializeField] private Text theCurrentText;
    [SerializeField] private PlayerLive playerLive;

    private int theBestTime;
    private int theCurrentTime;
    void Start()
    {
        
        theBestTime = PlayerPrefs.GetInt("theBestTime", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerLive.isDead == false)
        {
            theCurrentTime += PlayerPrefs.GetInt("currentSpeed") / 10;
        }
        else
        {
            return;
        }
        
        if(theCurrentTime > theBestTime)
        {
            theBestTime = theCurrentTime;
            PlayerPrefs.SetInt("theBestTime", theBestTime);

            theBestText. color = Color.green;
            theCurrentText.color = Color.green;

            theBestText.text = $"{theBestTime}";
            theCurrentText.text = $"{theCurrentTime}";
        }
        else
        {
            theBestText.color = Color.green;
            theCurrentText.color = Color.red;

            theBestText.text = $"{theBestTime}";
            theCurrentText.text = $"{theCurrentTime}";
        }

    }
}
