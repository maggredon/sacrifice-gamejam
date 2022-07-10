using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRandomizer : MonoBehaviour
{
    //Sound values
    [Range(0.1f, 0.5f)]
    [SerializeField] float volChange = 0.15f;
    [Range(0.1f, 0.5f)]
    [SerializeField] float pitch = 0.2f;
    private AudioSource source;
    //sound clips array
    [SerializeField] AudioClip[] sounds;

    public void RandomizeSound()
    {
        source.clip = sounds[Random.Range(0, sounds.Length)];
        source.volume = Random.Range(1 - volChange, 1);
        source.pitch = Random.Range(1 - pitch, 1 + pitch);
        source.Play();
    }

    public void RandomizeEffect(AudioClip clip)
    {
        source.clip = clip;
        source.volume = Random.Range(1 - volChange, 1);
        source.pitch = Random.Range(1 - pitch, 1 + pitch);
        source.Play();
    }

    //public void LoadCLip(AudioClip sound)
    //{
    //    source.clip = sound;
    //    source.volume = Random.Range(1 - volChange, 1);
    //    source.pitch = Random.Range(1 - pitch, 1 + pitch);
    //    source.Play();
    //}

}
