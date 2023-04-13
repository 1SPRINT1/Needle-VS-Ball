using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    public PlayerMove PM;
    public void SceneMen(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
