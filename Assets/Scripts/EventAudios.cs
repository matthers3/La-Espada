using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class EventAudios : MonoBehaviour
{

    private AudioSource audioSource;
    public AudioClip friendSound;
    public AudioClip ringSound;
    public AudioClip pickUp;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    [YarnCommand("play_friend")]
    public void PlayFriend() {
        audioSource.Stop();
        audioSource.loop = false;
        audioSource.PlayOneShot(pickUp);
        audioSource.PlayOneShot(friendSound);
    }

    [YarnCommand("play_ring")]
    public void PlayRing() {
        audioSource.loop = true;
        audioSource.clip = ringSound;
        audioSource.Play();
    }
}
