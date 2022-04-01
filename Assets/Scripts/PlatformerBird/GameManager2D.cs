using UnityEngine;
using UnityEngine.UI;

public class GameManager2D : MonoBehaviour
{
    public Player2D player;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject startpoint;
    

    private void Awake()
    {
        Application.targetFrameRate = 60;

        Pause();
    }

    public void Play()
    {        
        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        player.transform.position = startpoint.transform.position;
    }

    public void GameOver()
    {
        playButton.SetActive(true);
        gameOver.SetActive(true);

        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }
}
