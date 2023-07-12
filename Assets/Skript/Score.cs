using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    [SerializeField] private Text score;
    [SerializeField] private PlayerLive playerLive;
    int intScore;
    // Update is called once per frame
    void Update()
    {       
        if (playerLive.isDead == false)
        {
            intScore += PlayerPrefs.GetInt("currentSpeed") / 10;
            score.text = $"{intScore}";
        }
        else
        {
            return;
        }
    }    
}
