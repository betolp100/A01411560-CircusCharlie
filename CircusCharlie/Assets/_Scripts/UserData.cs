using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour {

    public static UserData instance = null;
    protected LevelManager lm;

    protected MusicManager musicManager;

    public int lives = 7;
    public int score;
    public int stage;

    private void Awake()
    {
        if (!musicManager) musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
        
        if (instance == null)
            instance = this;
        else if (instance != this)   //Singleton Algorythm
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start ()
    {
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        score = 0;
	}

	public void PlayerDead()
    {
        lives--;
        if (lives >= 0)
        {
                 if (stage == 0)
                lm.LoadLevel("level_00");
            else if (stage == 1)
                lm.LoadLevel("level_01");
            else if (stage == 2)
                lm.LoadLevel("level_02");
            else if (stage == 3)
                lm.LoadLevel("level_03");
            else if (stage == 4)
                lm.LoadLevel("level_04");
        } else
        {
            Debug.Log("MORIII");
            lm.LoadLevel("Lose");
            musicManager.PlaySong(1);
            musicManager.GetComponent<AudioSource>().loop = false;
            StartCoroutine(WaitUntilTheSoundEnds());
        }
    }

    IEnumerator WaitUntilTheSoundEnds()
    {
        yield return new WaitUntil(() => musicManager.GetComponent<AudioSource>().isPlaying==false);
        musicManager.PlaySong(0);
        musicManager.GetComponent<AudioSource>().loop = true;
    }

    public void PlayerWon(int sc)
    {
        stage++;
        int scoreMultiplier = 10000;
        score = sc * scoreMultiplier;
        StartCoroutine(ChangeScene());
        
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(3.5f);
        lm.LoadNextLevel();
        Debug.Log(stage);
    }
}
