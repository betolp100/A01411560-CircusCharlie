using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip[] audioClips;
    public AudioSource sound;
    protected static MusicManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)   //Singleton Algorythm
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }

    

    public void PlaySong(int i)    //Play sounds
    {
        /*if (i == 0)
        {
            if (sound.isPlaying == false)
            {
                sound.clip = audioClips[i];
                sound.Play();
            }
        }*/


            sound.clip=audioClips[i];
            sound.Play();
        
    }
}
