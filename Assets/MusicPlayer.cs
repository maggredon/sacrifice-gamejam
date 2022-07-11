using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip[] songs;
    public int version = 0;

    public void PlayMusic()
    {
        source.Play();
    }
    private int changed = 0;
    private int lastChanged = -1;

    public float time, timer;
    public void WaitToChange()
    {
        time += Time.deltaTime;
        timer = source.clip.length + 0.01f - source.time;
        if (time >= timer)
        {
            time = 0;
            switch (version)
            {
                case 1:
                    source.clip = songs[0];
                    changed = 0;
                    break;
                case 2:
                    source.clip = songs[1];
                    changed = 1;
                    break;
                case 3:
                    source.clip = songs[2];
                    changed = 2;
                    break;
                case 4:
                    source.clip = songs[3];
                    changed = 3;
                    break;
            }
        }
    }

    public void ChangeSong()
    {

        if (changed != lastChanged)
        {
            PlayMusic();
            lastChanged = changed;
        }

    }

    private void Update()
    {
        ChangeSong();
    }

    public void SetVersion(int ver)
    {
        version = ver;
        WaitToChange();
    }
    private void Start()
    {
        source.clip = songs[0];
    }
}
