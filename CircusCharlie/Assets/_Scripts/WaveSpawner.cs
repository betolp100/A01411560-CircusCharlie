using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public GameObject S_F_RingPrefab, B_F_RingPrefab, moneySack, monkeyPrefab, superMonkeyPrefab, birdPrefab;

    public Transform ringSpawner, monkeySpawner, birdSpawner;

    public int timeBetweenWaves;
    public int bonus;
    public float spawnerY, monkeySpawnerY, birdSpawnerY;

    private float countdown = 4f;

    protected UserData ud;

    private void Start()
    {
        ud = GameObject.Find("UserData").GetComponent<UserData>();
    }

    void Update ()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
    }

    IEnumerator SpawnWave()
    {
        switch (ud.stage)
        {
            case 0:
                {
                    if (bonus <= 0)
                    {
                        SpawnSmall_Fire_Ring();
                        bonus = 6;
                        yield return new WaitForSeconds(3F);
                    }
                    else
                    {
                        SpawnBig_Fire_Ring();

                        bonus--;
                        yield return new WaitForSeconds(3F);
                    }
                    break;
                }

            case 1:
                {
                    if (bonus <= 0)
                    {
                        SpawnSmall_Fire_Ring();
                        
                        bonus = 6;
                        yield return new WaitForSeconds(3F);
                        SpawnSuper_Monkey();
                        yield return new WaitForSeconds(1F);
                    }
                    else
                    {
                        
                        SpawnBig_Fire_Ring();
                        bonus--;
                        yield return new WaitForSeconds(3F);
                        SpawnDefault_Monkey();
                        yield return new WaitForSeconds(1F);

                    }
                    break;
                }
            case 2:
                {
                    if (bonus <= 0)
                    {
                        SpawnSmall_Fire_Ring();

                        bonus = 6;
                        yield return new WaitForSeconds(3F);
                        SpawnSuper_Monkey();
                        SpawnBird();
                        yield return new WaitForSeconds(1F);
                    }
                    else
                    {
                        SpawnBig_Fire_Ring();
                        bonus--;
                        yield return new WaitForSeconds(3F);
                        SpawnDefault_Monkey();
                        yield return new WaitForSeconds(1F);
                    }
                    break;
                }
            case 3:
                {
                    if (bonus <= 0)
                    {
                        SpawnSmall_Fire_Ring();

                        bonus = 6;
                        yield return new WaitForSeconds(3F);
                        SpawnSuper_Monkey();
                        SpawnBird();
                        yield return new WaitForSeconds(1F);
                    }
                    else
                    {
                        SpawnBig_Fire_Ring();
                        bonus--;
                        yield return new WaitForSeconds(3F);
                        SpawnDefault_Monkey();
                        yield return new WaitForSeconds(1F);
                    }
                    break;
                }
            case 4:
                {
                    if (bonus <= 0)
                    {
                        SpawnSmall_Fire_Ring();

                        bonus = 6;
                        yield return new WaitForSeconds(3F);
                        SpawnSuper_Monkey();
                        
                        yield return new WaitForSeconds(1F);
                    }
                    else
                    {
                        SpawnBig_Fire_Ring();
                        bonus--;
                        yield return new WaitForSeconds(3F);
                        SpawnDefault_Monkey();
                        SpawnBird();
                        yield return new WaitForSeconds(1F);
                    }
                    break;
                }
        }
    }

    void SpawnBig_Fire_Ring()
    {
        Instantiate(B_F_RingPrefab, new Vector3 (ringSpawner.position.x,spawnerY,0), Quaternion.identity);
    }

    void SpawnSmall_Fire_Ring()
    {
            Instantiate(S_F_RingPrefab, new Vector3(ringSpawner.position.x, spawnerY, 0), Quaternion.identity);
    }



    void SpawnSuper_Monkey()
    {
        Instantiate(superMonkeyPrefab, new Vector3(monkeySpawner.position.x, monkeySpawnerY, 0), Quaternion.identity);
    }

    void SpawnDefault_Monkey()
    {
        Instantiate(monkeyPrefab, new Vector3(monkeySpawner.position.x, monkeySpawnerY, 0), Quaternion.identity);
    }


    void SpawnBird()
    {
        Instantiate(birdPrefab, new Vector3(birdSpawner.position.x, birdSpawnerY, 0), Quaternion.identity);
    }
}
