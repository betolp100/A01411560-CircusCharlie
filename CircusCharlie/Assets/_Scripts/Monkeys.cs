using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkeys : MonoBehaviour {

    protected UserData ud;
    public bool isSuper;
    public int speed;

    protected Rigidbody2D rigi;

	void Start ()
    {
        ud = GameObject.Find("UserData").GetComponent<UserData>();
        rigi = GetComponent<Rigidbody2D>();
          
    }

    void Update()
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
