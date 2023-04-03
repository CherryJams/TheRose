using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;


public class AudioPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    [YarnCommand("play")]
    public void PlaySound()
    {
        audioSource.Play();
    }
    
    [YarnCommand("fadeAudio")]
    public void Fade(float duration, float targetVolume)
    {
        StartCoroutine(StartFade(duration, targetVolume));
    }

    public IEnumerator StartFade( float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }

        yield break;
    }
}