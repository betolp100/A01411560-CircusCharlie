using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour {
    private int once;
    public Text space;
    public Text score;
    protected UserData ud;
    protected LevelManager lm;
    private void Start()
    {
        
        once = 0;
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        space = GameObject.Find("MENU").GetComponent<Text>();
        score.text= GameObject.Find("UserData").GetComponent<UserData>().score.ToString();


        GameObject.Find("UserData").GetComponent<UserData>().score = 0;
        GameObject.Find("UserData").GetComponent<UserData>().lives = 7;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && once == 0)
        {
            Debug.Log("HOLA");
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
        lm.LoadLevel("Start");
    }

}