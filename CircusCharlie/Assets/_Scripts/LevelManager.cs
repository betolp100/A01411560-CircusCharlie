using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    protected UserData userData;
    protected Player player;
    protected PlayerStats gameMaster;
    Scene currentScene;
    
    public static LevelManager instance = null;


    private void Awake()
    {
            if (instance == null)
                instance = this;
            else if (instance != this)   //Singleton Algorythm
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (userData != null)
        {
            userData = GameObject.Find("UserData").GetComponent<UserData>();
            currentScene = SceneManager.GetActiveScene();
            player = GameObject.Find("Player").GetComponent<Player>();
            gameMaster = GameObject.Find("GameMaster").GetComponent<PlayerStats>();
        }
    }

    public void QuitLevel()
    {
        Debug.Log("Game Finished");
        Application.Quit();   //End game
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }   //Load level

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  //Load next level
    }
    private void Update()
    {

    }
}
