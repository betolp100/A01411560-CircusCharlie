using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GIF : MonoBehaviour {

    public Texture2D[] frames;
    public int fps = 10;
    private int index;

    void Update()
    {
        if (index <= 73)
        {
            index = (int)(Time.time * fps) % frames.Length;
            GetComponent<RawImage>().texture = frames[index];
        }
    }
}
