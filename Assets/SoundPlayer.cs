using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip clip;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    public void ToggleSound()
    {
        if (audio.isPlaying)
        {
            audio.Stop();
        }
        else
        {
            audio.PlayOneShot(clip);
        }
    }
}
