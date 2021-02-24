using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlappyGameManager : MonoBehaviour
{
    public bool StartGame = false;
    public GameObject[] MenuObjects;
    public GameObject puntuacionText;
    public GameObject GameOverObj;
    public GameObject Bird;
    private bool InGame = false;
    public Sprite deadBird;
    private int Puntuacion = 0;
    private int BestPuntuacion = 0;
    public Text scr1;
    public Text scr2;
    public GameObject Medalla;
    public Sprite Oro;
    public Sprite Plata;
    public Sprite Bronce;
    public GameObject BirdPref;

    private void Start()
    {
        BestPuntuacion = PlayerPrefs.GetInt("puntos", BestPuntuacion);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && StartGame == false)
        {
            SceneManager.LoadScene("Main");

        }

        if (Input.GetKeyDown(KeyCode.Space) && StartGame == false && InGame == true)
        {
            SceneManager.LoadScene("Flappy_Scene");
        }

        if (Input.GetKeyDown(KeyCode.Space) && StartGame == false && InGame == false)
        {
            StartGame = true;
            MenuObjects[0].GetComponent<Animator>().SetBool("EndTitle", true);
            MenuObjects[1].GetComponent<Animator>().SetBool("EndText", true);
            MenuObjects[2].GetComponent<Animator>().SetBool("EndText", true);
            Bird.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }

        if(Puntuacion > 0)
        {
            puntuacionText.SetActive(true);
        }
    }

    public void SumarPunto()
    {
        puntuacionText.SetActive(true);
        Puntuacion++;
        puntuacionText.GetComponent<Text>().text = Puntuacion.ToString();
    }

    public void GameOver()
    {

        if(Puntuacion > BestPuntuacion)
        {
            BestPuntuacion = Puntuacion;
            PlayerPrefs.SetInt("puntos", BestPuntuacion);
            PlayerPrefs.Save();
        }

        StartGame = false;
        InGame = true;
        Bird.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        Bird.GetComponent<CapsuleCollider2D>().enabled = false ;
        Bird.GetComponent<SpriteRenderer>().sprite = deadBird;
        scr1.text = Puntuacion.ToString();
        scr2.text = BestPuntuacion.ToString();
        if(Puntuacion < 10)
        {
            Medalla.GetComponent<SpriteRenderer>().sprite = Bronce;
        }else if( Puntuacion > 10)
        {
            Medalla.GetComponent<SpriteRenderer>().sprite = Plata;

        }
        else if(Puntuacion > 40)
        {
            Medalla.GetComponent<SpriteRenderer>().sprite = Oro;
        }
        GameOverObj.SetActive(true);
        puntuacionText.gameObject.GetComponent<Text>().enabled = false;
    }
}
