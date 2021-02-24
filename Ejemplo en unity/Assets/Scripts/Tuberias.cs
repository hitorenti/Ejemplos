using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuberias : MonoBehaviour
{
    public float velocidad;

    private void Update()
    {
        transform.position += Vector3.left * velocidad * Time.deltaTime;
    }
}
