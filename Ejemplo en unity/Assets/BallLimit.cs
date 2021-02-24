using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLimit : MonoBehaviour
{
    public BallManager mn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(collision.gameObject);
            mn.RestarVida();
        }
    }

}
