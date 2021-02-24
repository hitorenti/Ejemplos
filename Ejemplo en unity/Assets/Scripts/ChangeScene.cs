using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void SceneFlappy()
    {
        SceneManager.LoadScene("Flappy_Scene");
    }

    public void SceneBross()
    {
        SceneManager.LoadScene("BrickScene");

    }
}
