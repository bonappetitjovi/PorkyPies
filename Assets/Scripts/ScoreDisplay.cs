using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI highscoreText; // Reference to the TextMeshProUGUI component

    void Start()
    {
        // Get the highscore from PlayerPrefs
        int highscore = PlayerPrefs.GetInt("MaxRun", 0);

        // Display the highscore in the TextMeshProUGUI element
        if(highscore<=5)
        highscoreText.text = "Git Gud: " + highscore.ToString();
        if(highscore>5&&highscore<15)
        highscoreText.text = "Hmmmmm: " + highscore.ToString();
        if(highscore>15&&highscore<25)
        highscoreText.text = "Not Bad: " + highscore.ToString();
        if(highscore>25&&highscore<50)
        highscoreText.text = "Big Show: " + highscore.ToString();
        if(highscore>50&&highscore<100)
        highscoreText.text = "Top Dog: " + highscore.ToString();
        if(highscore>100&&highscore<1000)
        highscoreText.text = "Centurion: " + highscore.ToString();
        if(highscore>1000)
        highscoreText.text = "Comma Club: " + highscore.ToString();
    }
}
