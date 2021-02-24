using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public BarMovement Bm;
    public float force = 2.0f;
    public BallManager Man;
    private bool IsGround = false;

    // Start is called before the first frame update
    void Start()
    {
        Man = GameObject.Find("Manager").GetComponent<BallManager>();
        Bm = GameObject.Find("Bar").GetComponent<BarMovement>();
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && Man.InGame.Equals(false) && Man.GameOverBool.Equals(false))
        {
            Man.InGame = true;
            rb2d.bodyType = RigidbodyType2D.Dynamic;
            
            if(Input.GetAxis("Horizontal") > 0)
            {
                rb2d.velocity = Vector2.one * force;
            }
            else if(Input.GetAxis("Horizontal") < 0)
            {
                rb2d.velocity = new Vector2(-force, force);
            }
            else
            {
                rb2d.velocity = Vector2.up * force;

            }

            this.transform.parent = null;
        }

        if (Input.GetAxis("Horizontal") > 0 && Man.InGame && IsGround)
        {
            rb2d.velocity += Vector2.one * 0.2f;
        }
        else if (Input.GetAxis("Horizontal") < 0 & Man.InGame && IsGround) 
        {
            rb2d.velocity += new Vector2(-0.2f, 0.2f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("brick"))
        {
            Destroy(collision.gameObject);
            Man.AddScore();
        }

        if (collision.gameObject.name.Equals("Bar"))
        {
            IsGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Bar"))
        {
            IsGround = false;
        }
    }
}
