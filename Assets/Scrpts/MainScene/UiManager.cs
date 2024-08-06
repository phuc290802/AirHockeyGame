using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject CanvasGame;
    public GameObject CanvasRestart;

	[Header("CanvasRestart")]
	public GameObject WinTxt;
    public GameObject LooseTxt;
	public GameObject WinBlue;
	public GameObject WinRed;

	[Header("Other")]
    public AudioManager audioManager;
    public ScoreScript scoreScript;

    public PuckScript puckScript;
    public PlayerMove playermove;
    public AiScript aiScript;

    public MovePlayerRed movePlayerRed;
    public MoveWithKey moveWithKey;

    public void ShowRestartCanvas(bool didAiWin,bool WhoWin)
    {
        Time.timeScale = 0;
        CanvasGame.SetActive(false);
        CanvasRestart.SetActive(true);
        if (GameValues.IsMultiplayer)
        {
            if (WhoWin)
            {
                audioManager.PlayWonGame();
                WinBlue.SetActive(false);
                WinRed.SetActive(true);
                WinTxt.SetActive(false);
                LooseTxt.SetActive(false);
            }
            else
            {
                audioManager.PlayWonGame();
                WinBlue.SetActive(true);
                WinRed.SetActive(false);
                WinTxt.SetActive(false);
                LooseTxt.SetActive(false);
            }
        }
        else
        {
            if (didAiWin)
            {
                audioManager.PlayLostGame();
                WinTxt.SetActive(false);
                LooseTxt.SetActive(true);
                WinBlue.SetActive(false);
                WinRed.SetActive(false);
            }
            else
            {
                audioManager.PlayWonGame();
                WinTxt.SetActive(true);
                LooseTxt.SetActive(false);
                WinBlue.SetActive(false);
                WinRed.SetActive(false);
            }
        }
    }
       
    public void RestartGame()
    {
        Time.timeScale = 1;
        CanvasGame.SetActive(true);
        CanvasRestart.SetActive(false);

        scoreScript.ResetScores();
        puckScript.CenterPuck();    
        playermove.ResetPosition();
        aiScript.ResetPosition();
    }

    public void ShowMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("menu");
    }
}
