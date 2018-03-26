using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject left, center, right;
    public GameObject clownPlayer, lionPlayer;
    int sendOnce = 0;
    public float speed;

    protected PlayerStats ps;
    protected UserData ud;

    private bool grounded, crouched;
    [HideInInspector]
    public bool dead, win;
    private int playOnce;

    protected SoundManager soundManager;
    protected Rigidbody2D rigi;
    protected Animator lion, clown;

	void Start ()
    {
        win         = false;
        grounded    = true;
        dead        = false;
        crouched    = false;
        ud      = GameObject.Find("UserData").GetComponent<UserData>();
        clown   = clownPlayer.GetComponent<Animator>();
        lion    = lionPlayer.GetComponent<Animator>();
        rigi    = GetComponent<Rigidbody2D>();
        ps      = GameObject.Find("GameMaster").GetComponent<PlayerStats>();
        playOnce = 0;
    }

    private void Awake()
    {
        if (!soundManager) soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftArrow) == true || Input.GetKeyDown(KeyCode.RightArrow) == true && Input.GetKeyDown(KeyCode.DownArrow) == true))
        {
            lion.SetBool("isCrouching", true);
            clown.SetBool("isCrouching", true);
        }

        Debug.Log(crouched);
        if (dead == false || win==true)
        {
            if (grounded == true && crouched==false)
            {
                if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.DownArrow))
                {
                    lion.SetBool("isRunningFW", true);
                    clown.SetBool("isRunningFW", true);
                    transform.Translate(Vector3.right * speed * Time.deltaTime);
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        soundManager.PlaySong(0);
                        lion.SetBool("isRunningFW", false);
                        clown.SetBool("isRunningFW", false);
                        rigi.AddForce(new Vector2(6, 13.5f), ForceMode2D.Impulse);
                        grounded = false;
                    }
                }
                else if(!Input.GetKey(KeyCode.RightArrow))
                {
                    lion.SetBool("isRunningFW", false);
                    clown.SetBool("isRunningFW", false);
                }


                if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.DownArrow))
                {
                    lion.SetBool("isRunningBW", true);
                    clown.SetBool("isRunningBW", true);
                    transform.Translate(Vector3.left * speed * Time.deltaTime);
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        soundManager.PlaySong(0);
                        lion.SetBool("isRunningBW", false);
                        clown.SetBool("isRunningBW", false);
                        rigi.AddForce(new Vector2(-6, 13.5f), ForceMode2D.Impulse); //
                    }
                }else if (!Input.GetKey(KeyCode.LeftArrow))
                {
                    lion.SetBool("isRunningBW", false);
                    clown.SetBool("isRunningBW", false);
                } //returning to idle
            

                if ((Input.GetKeyDown(KeyCode.UpArrow)))
                {
                    lion.SetBool("isRunningFW", false);
                    clown.SetBool("isRunningFW", false);
                    if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
                    {
                        soundManager.PlaySong(0);
                        rigi.AddForce(new Vector2(0, 13.5f), ForceMode2D.Impulse);
                    }
                }

                if ((Input.GetKeyDown(KeyCode.LeftArrow) == true || Input.GetKeyDown(KeyCode.RightArrow) == true && Input.GetKeyDown(KeyCode.DownArrow) == true))
                {
                    lion.SetBool("isCrouching", true);
                    clown.SetBool("isCrouching", true);
                } 

                

                if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
                {
                    lion.SetBool("isCrouching", false);
                    clown.SetBool("isCrouching", false);
                    lion.SetBool("isRunningFW", false);
                    clown.SetBool("isRunningFW", false);
                    lion.SetBool("isRunningBW", false);
                    clown.SetBool("isRunningBW", false);
                    lion.SetBool("isJumping", false);

                }
                

            }
            if (Input.GetKey(KeyCode.DownArrow) && grounded == true)
            {
                lion.SetBool("isCrouching", true);
                clown.SetBool("isCrouching", true);
                crouched = true;
            }
            else
            {
                lion.SetBool("isCrouching", false);
                clown.SetBool("isCrouching", false);
                crouched = false;

            }



        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Enemy")
        {
            if (sendOnce == 0)
            {
                lion.SetBool("isDead", true);
                clown.SetBool("isDead", true);
                dead = true;
                ud.PlayerDead();
            }
            sendOnce++;
        }
        else if (coll.gameObject.tag == "End")
        {
            if (playOnce == 0)
            {
                
                soundManager.PlaySong(1);
                clown.SetBool("Won",true);
                    
                left.GetComponent<Claps>().levelComplete = true;
                center.GetComponent<Claps>().levelComplete = true;
                right.GetComponent<Claps>().levelComplete = true;
                ud.lives = 7;
                win = true;
                ps.PlayerWon();

                playOnce++;
            }
        }

    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Floor" || coll.gameObject.tag == "End")
        {
            lion.SetBool("isJumping", false);
            grounded = true;

        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Floor" || coll.gameObject.tag == "End")
        {
            lion.SetBool("isJumping",true);
            grounded = false;
        }
    }
}
