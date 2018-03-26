using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claps : MonoBehaviour {

    private int clapOnce;
    public float tm;
    [HideInInspector]
    public bool levelComplete;
    public Sprite first, second;
    

    protected SpriteRenderer spr;

	void Start ()
    {
        clapOnce = 0;
        levelComplete = false;
        spr = GetComponent<SpriteRenderer>();

        spr.sprite = first;
    }
	
	// Update is called once per frame
	void Update () {
        if (levelComplete == true&&clapOnce<=0)
        {
            StartCoroutine(SwapSprites());
        }	
	}

    IEnumerator SwapSprites()
    {
        levelComplete = false;
        clapOnce++;
        spr.sprite = first;
        yield return new WaitForSeconds(tm);
        spr.sprite = second;
        yield return new WaitForSeconds(tm);
        spr.sprite = first;
        yield return new WaitForSeconds(tm);
        spr.sprite = second;
        yield return new WaitForSeconds(tm);
        spr.sprite = first;
        yield return new WaitForSeconds(tm);
        spr.sprite = second;
        yield return new WaitForSeconds(tm);
        spr.sprite = first;
        yield return new WaitForSeconds(tm);
        spr.sprite = second;
        yield return new WaitForSeconds(tm);
        spr.sprite = first;
        yield return new WaitForSeconds(tm);
        spr.sprite = second;
        yield return new WaitForSeconds(tm);
        spr.sprite = first;
        
        
    }
}
