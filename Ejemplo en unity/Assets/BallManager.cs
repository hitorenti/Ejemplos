using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallManager : MonoBehaviour
{

    public static int Life = 5;
    public bool InGame = false;
    public bool GameOverBool = false;
    public bool Win = false;
    public static int score = 0;
    public static int BestScore = 0;
    public Text ScoreText;
    public GameObject BallPrefab;
    public Transform Bar;
    public Text LifeText;
    public GameObject PanelGameOver;
    public GameObject PanelWin;
    public GameObject BricksAnim;
    public Text Sco;
    public Text BSco;

    private void Start()
    {
        BestScore = PlayerPrefs.GetInt("BScoreBall");
        Life = 5;
        score = 0;
    }

    private void Update()
    {
        if (GameOverBool && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("BrickScene");
        }

        if (GameOverBool && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main");
        }

        if (Win && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("BrickScene");
        }

        if (Win && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main");
        }
    }

    public void AddScore()
    {
        score++;
        ScoreText.text = string.Format("Score: {0}",score);
        if(score >= 32)
        {
            InGame = false;
            PanelWin.SetActive(true);
            BricksAnim.SetActive(false);
            Bar.position = new Vector3(10000, 10000, 1000);
            Win = true;
            if (score > BestScore)
            {
                PlayerPrefs.SetInt("BScoreBall", score);
            }
            PlayerPrefs.Save();
        }
    }

    public void RestarVida()
    {
        if (Life > 0)
        {
            Life--;
            LifeText.text = string.Format("Lifes: {0}", Life);
            Bar.position = new Vector3(0, Bar.position.y, Bar.position.z);
            Instantiate(BallPrefab, Bar);
            InGame = false;

        }

        if (Life == 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        BSco.text = "Best Score: " + BestScore.ToString();
        GameOverBool = true;
        Sco.text = "Score: " + score.ToString();
        PanelGameOver.SetActive(true);
        BricksAnim.SetActive(false);
        Bar.position = new Vector3(10000,10000,1000);
       if(score > BestScore)
        {
            PlayerPrefs.SetInt("BScoreBall",score);
        }
        PlayerPrefs.Save();
    }

}
