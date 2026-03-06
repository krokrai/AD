using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;

    private void Awake()
    {
        if ( instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SceneChanger(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void SceneChanger(Scenes scene )
    {
        SceneManager.LoadScene((int)scene);
    }
}