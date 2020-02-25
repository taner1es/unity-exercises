using UnityEngine;
using UnityEngine.UI;
public class DiceGame : MonoBehaviour
{
    public Text dice;
    public Text highScoreDice;

    int highscore = 0;

    private void Start()
    {
        highscore = PlayerPrefs.GetInt("HighScore");
        if (highscore > 0) highScoreDice.text = highscore.ToString();
        else highScoreDice.text = "xx";
    }

    public void RollDice()
    {
        int number = Random.Range(1, 7);
        dice.text = number.ToString();

        if(number > highscore)
        {
            highscore = number;
            highScoreDice.text = highscore.ToString();
            PlayerPrefs.SetInt("HighScore", highscore);
        }
        
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteAll();

        highscore = 0;
        highScoreDice.text = "xx";
        dice.text = "xx";
    }
}
