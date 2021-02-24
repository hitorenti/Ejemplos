using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyCamera : MonoBehaviour
{
    public float power = 0.7f;
    public float duration = 1.0f;
    public Transform camera;
    public float slowDownAmount = 1.0f;
    public bool shake = false;

    Vector3 startPosition;
    float initialDuration;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
        startPosition = camera.localPosition;
        initialDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (shake)
        {
            if(duration > 0)
            {
                camera.localPosition = startPosition + Random.insideUnitSphere * power;
            }
            else
            {
                shake = false;
                duration = initialDuration;
                camera.localPosition = startPosition;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject man = GameObject.FindGameObjectsWithTag("MANAGER")[0];
        man.GetComponent<FlappyGameManager>().GameOver();
    }
}
