using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarMovement : MonoBehaviour
{
    public BallManager Bm;
    public float speed = 0f;

    // Update is called once per frame
    void Update()
    {

        if (Bm.GameOverBool.Equals(false))
        {
            float mvX = Input.GetAxis("Horizontal");

            if (this.transform.position.x <= 7.30f && mvX > 0)
            {
                this.transform.position += new Vector3(mvX, 0, 0) * Time.deltaTime * speed;
            }


            if (this.transform.position.x >= -7.30f && mvX < 0)
            {
                this.transform.position += new Vector3(mvX, 0, 0) * Time.deltaTime * speed;
            }
        }
    }
}
