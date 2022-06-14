using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagement : MonoBehaviour
{
    public AudioClip shootSFXSource;
    public AudioClip hitSFXSource;

    AudioSource audioSource;



    public AudioClip shootSFX { get; set; }
    public AudioClip hitSFX { get; set; }

    private static SoundManagement instance;
    public static SoundManagement Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject sound = new GameObject("SoundManagement");
                sound.AddComponent<SoundManagement>();
            }
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        shootSFX = shootSFXSource;
        hitSFX = hitSFXSource;
    }


    public void playShootSound()
    {
        audioSource.PlayOneShot(shootSFX, 0.3f);
    }

    public void playHitSound()
    {
        audioSource.PlayOneShot(hitSFX, 0.3f);
    }

    // Update is called once per frame

}
