using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSound : MonoBehaviour
{
    [SerializeField] float mfTimeBetweenSounds = 5f;
    [SerializeField] AudioClip[] mZombieSounds;

    AudioSource mAudioSource;


    private void Awake()
    {
        mAudioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        //InvokeRepeating("PlaySound", Random.Range(0, 5.0f), mfTimeBetweenSounds);
        Invoke("PlaySound", Random.Range(0, 5.0f));
    }


    void PlaySound()
    {
        int liRandmAudioIndex = Random.Range(0, mZombieSounds.Length);
        //AudioSource.PlayClipAtPoint(mZombieSounds[liRandmAudioIndex], this.transform.position);

        mAudioSource.clip = mZombieSounds[liRandmAudioIndex];
        mAudioSource.Play();

        Invoke("PlaySound", mAudioSource.clip.length + mfTimeBetweenSounds);
    }
}
