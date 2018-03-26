﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRings : MonoBehaviour {

    public float speed;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        
        if (coll.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }


}
