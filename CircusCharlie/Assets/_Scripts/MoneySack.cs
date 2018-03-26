using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySack : MonoBehaviour {

    protected UserData userData;
    public int scorePerAction;

	void Start ()
    {
        userData = GameObject.Find("UserData").GetComponent<UserData>();
	}

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            
            userData.score = userData.score + scorePerAction;
            Destroy(gameObject);
        }
    }


}
