using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//MainGame: UI Canvas
public class UIFunction : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject pauseButton;
    public GameObject scoreText;

    public void load(string levelName) 
    {
        Application.LoadLevel(levelName);
        Time.timeScale = 1;
    }
    public void pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void updateScore(int score) 
    {
        scoreText.GetComponent<Text>().text = "Score: " + score;
    }

    public void resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void gameOver()
    {
        gameOverMenu.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void restartGame() 
    {
        Application.LoadLevel(Application.loadedLevel);
    }

	// Update is called once per frame
	void Update () {
        updateScore((int)Time.time );
	}
}
