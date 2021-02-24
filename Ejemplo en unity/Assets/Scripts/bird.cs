using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    public float velocidad = 1.0f;
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GameObject man = GameObject.FindGameObjectsWithTag("MANAGER")[0];

        if (Input.GetKeyDown(KeyCode.Space) && man.GetComponent<FlappyGameManager>().StartGame.Equals(true))
        {
            // Salto
            rb2d.velocity = Vector2.up * velocidad;

        }   
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject man = GameObject.FindGameObjectsWithTag("MANAGER")[0];

        if (man.GetComponent<FlappyGameManager>().StartGame)
        {
            // Perdida por el suelo
            switch (collision.gameObject.tag)
            {
                case "Ground":
                    man.GetComponent<FlappyGameManager>().GameOver();
                    break;
                case "Tubo":
                    man.GetComponent<FlappyGameManager>().GameOver();
                    break;
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Punto"))
        {
            GameObject man = GameObject.FindGameObjectsWithTag("MANAGER")[0];
            man.GetComponent<FlappyGameManager>().SumarPunto();
        }
    }
}
