using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscores : MonoBehaviour
{
    public static int score;
    public static int highscore;
    //stores current score
    [SerilalizeField] Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        score = 0;
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        scoreText.text = highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(score > highscore)
        {
            highscore = score;
            scoreText.text = "" + score;

            PlayerPrefs.SetInt ("highscore", highscore);
        }
    }
}
