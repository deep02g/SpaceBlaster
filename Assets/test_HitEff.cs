using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_HitEff : MonoBehaviour
{
    public static AudioClip playerHitSound;
    private static AudioSource m_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("dsoof");
        m_AudioSource = GetComponent<AudioSource>();
    }

    
    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "Hit" :
                m_AudioSource.Play();
                break;
        } 
    }
}
