using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    protected UserData userData;
    protected Image sr1, sr2, sr3, sr4, sr5, sr6, sr7;
    private float timeLeft;
    private int counterInt;
    private PlayerStats instance;
    public Text score, stage, counterT;
    public Image[] lives;

    void Start ()
    {
        userData = GameObject.Find("UserData").GetComponent<UserData>();
        sr1 = lives[0].GetComponent<Image>();
        sr2 = lives[1].GetComponent<Image>();
        sr3 = lives[2].GetComponent<Image>();
        sr4 = lives[3].GetComponent<Image>();
        sr5 = lives[4].GetComponent<Image>();
        sr6 = lives[5].GetComponent<Image>();
        sr7 = lives[6].GetComponent<Image>();
        timeLeft = 150;
    }
	
	// Update is called once per frame
	void Update ()
    {
        score.text = userData.score.ToString();   //some user interface game stats command

        timeLeft -= Time.deltaTime;
        counterInt = Mathf.FloorToInt(timeLeft);
        counterT.text = counterInt.ToString();
        stage.text = (userData.stage+1).ToString();

        if (userData.lives== 7)
        {
        }else
        if (userData.lives == 6)
        {
            sr7.enabled = false;
        }
        else
        if (userData.lives == 5)
        {
            sr7.enabled = false;
            sr6.enabled = false;
        }
        else
        if (userData.lives == 4)
        {
            sr7.enabled = false;
            sr6.enabled = false;
            sr5.enabled = false;
        }
        else
        if (userData.lives == 3)
        {
            sr7.enabled = false;
            sr6.enabled = false;
            sr5.enabled = false;
            sr4.enabled = false;
        }
        else
        if (userData.lives == 2)
        {
            sr7.enabled = false;
            sr6.enabled = false;
            sr5.enabled = false;
            sr4.enabled = false;
            sr3.enabled = false;
        }
        else
        if (userData.lives == 1)
        {
            sr7.enabled = false;
            sr6.enabled = false;
            sr5.enabled = false;
            sr4.enabled = false;
            sr3.enabled = false;
            sr2.enabled = false;
        }
        else
        if (userData.lives == 0)
        {
            sr7.enabled = false;
            sr6.enabled = false;
            sr5.enabled = false;
            sr4.enabled = false;
            sr3.enabled = false;
            sr2.enabled = false;
            sr1.enabled = false;
        }
    }

    public void PlayerWon()
    {

        userData.PlayerWon(counterInt);
    }
}
