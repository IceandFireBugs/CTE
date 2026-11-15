using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RepeatingSFX : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioClip sfxClip;
    [Tooltip("Time in seconds between each sound.")]
    public float interval = 2.0f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(PlaySoundLoop());
    }

    IEnumerator PlaySoundLoop()
    {
        while (true)
        {
            if (sfxClip != null)
            {
                audioSource.PlayOneShot(sfxClip);
            }

            yield return new WaitForSeconds(interval);
        }
    }
}
