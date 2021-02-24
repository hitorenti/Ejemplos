using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float maxTime = 1;
    public float timer = 0;
    public GameObject Tubos;
    public float Height;

    // Update is called once per frame
    void Update()
    {
        GameObject man = GameObject.FindGameObjectsWithTag("MANAGER")[0];

        if (man.GetComponent<FlappyGameManager>().StartGame)
        {
            if (timer > maxTime)
            {
                GameObject newTub = Instantiate(Tubos);
                newTub.transform.position = this.transform.position + new Vector3(0, Random.Range(-Height, Height), 0);
                Destroy(newTub, 15);
                timer = 0;
            }

            timer += Time.deltaTime;
        }

    }
}
