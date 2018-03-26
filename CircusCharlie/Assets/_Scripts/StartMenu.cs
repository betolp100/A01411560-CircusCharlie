using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class StartMenu : MonoBehaviour {
    private int once;

    public Text space;
    protected LevelManager lm;
    protected SoundManager soundManager;
    protected MusicManager musicManager;        
    private void Start()
    {
        once = 0;
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        space = GameObject.Find("Space").GetComponent<Text>();
    }

    private void Awake()
    {
        if (!soundManager) soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        if (!musicManager) musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
    }


    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space)&&once==0)
        {
            StartCoroutine(Sparkle());
           
        }
        else if (Input.GetKeyDown(KeyCode.Z) == true)
        {
            lm.QuitLevel();
        }
    }
    IEnumerator Sparkle()
    {
        once++;
        soundManager.PlaySong(1);
        space.enabled = false;
        yield return new WaitForSeconds(.3f);
        space.enabled = true;
        yield return new WaitForSeconds(.3f);
        space.enabled = false;
        yield return new WaitForSeconds(.3f);
        space.enabled = true;
        yield return new WaitForSeconds(.3f);
        space.enabled = false;
        yield return new WaitForSeconds(.3f);
        space.enabled = true;
        yield return new WaitForSeconds(.5f);
        lm.LoadNextLevel();
        musicManager.PlaySong(0);
    }
   
}
