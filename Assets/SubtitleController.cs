using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SubtitleController : MonoBehaviour
{
    [SerializeField] TMP_Text subtitles;
    [SerializeField] AudioSource fatherSource;
    [SerializeField] AudioSource antagonistSource;
    [SerializeField] AudioClip gunshot;
    void Start()
    {
        PlayFatherSounds();
        subtitles.SetText("I have to get my kids out of this place...");
        StartCoroutine(RemoveSubtitlesAfterSeconds(2f));
        StartCoroutine(StopFatherTalk(2f));
    }


    public void EscapeCage()
    {
        PlayFatherSounds();
        subtitles.text = "Finally, now how do I get up there?";
        StartCoroutine(RemoveSubtitlesAfterSeconds(2f));
        StartCoroutine(StopFatherTalk(2f));
    }

    public void EnterSecondRoom()
    {
        PlayFatherSounds();
        subtitles.text = "CHILDREN! I'm here, I'll get you out!";
        StartCoroutine(RemoveSubtitlesAfterSeconds(2f));
        StartCoroutine(StopFatherTalk(2f));
    }

    public void FindAxe()
    {
        PlayFatherSounds();
        subtitles.text = "An axe, it can help me with all those crates...";
        StartCoroutine(RemoveSubtitlesAfterSeconds(2f));
        StartCoroutine(StopFatherTalk(2f));
    }

    public void FindCrowbar()
    {
        PlayFatherSounds();
        subtitles.text = "Finally, I can use this.";
        StartCoroutine(RemoveSubtitlesAfterSeconds(1.5f));
        StartCoroutine(StopFatherTalk(1.5f));
    }

    public void AttemptPryingCage()
    {
        PlayFatherSounds();
        subtitles.text = "I'm here, don't worry kids!";
        StartCoroutine(RemoveSubtitlesAfterSeconds(1.5f));
        StartCoroutine(StopFatherTalk(1.5f));
    }

    public void EvilGuyWalksIn()
    {
        StartCoroutine(EvilGuyWalksInCoroutine());
    }

    public void MakeYourChoice()
    {
        PlayAntagonistSounds();
        subtitles.text = "Make your choice.";
        StartCoroutine(RemoveSubtitlesAfterSeconds(1.5f));
        StartCoroutine(StopAntagonistTalk(1.5f));
    }

    public void ChoiceMade()
    {
        PlayAntagonistSounds();
        subtitles.text = "And you would leave your kid so easily? You thought you actually had a choice?";
        StartCoroutine(RemoveSubtitlesAfterSeconds(4f));
        StartCoroutine(StopAntagonistTalk(2f));
        //MAKE BLACK FADE TRANSITION
        GunshotSounds();
    }

    //PLAY SOUNDS
    public void GunshotSounds()
    {
        //play gunshot sound 3 times
        StartCoroutine(ThreeGunshots());
        StartCoroutine(OpenEndScreen(5f));
    }

    private void PlayFatherSounds()
    {
        fatherSource.Play();
    }

    private void PlayAntagonistSounds()
    {
        antagonistSource.Play();
    }

    //STOP SOUNDS
    private IEnumerator StopFatherTalk(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        fatherSource.Stop();
    }

    private IEnumerator StopAntagonistTalk(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        antagonistSource.Stop();
    }

    //OTHER COROUTINES
    private IEnumerator RemoveSubtitlesAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        subtitles.SetText(" ");
    }

    private IEnumerator OpenEndScreen(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        subtitles.SetText(" ");
    }

    private IEnumerator EvilGuyWalksInCoroutine()
    {
        yield return new WaitForSeconds(5f);
        //play talking sounds for 2 seconds
        PlayAntagonistSounds();
        subtitles.text = "HE requires a sacrifice.";
        StartCoroutine(RemoveSubtitlesAfterSeconds(2f));
        StartCoroutine(StopAntagonistTalk(2f));
    }

    private IEnumerator ThreeGunshots()
    {
        //waits 2 seconds and then plays the gunshots
        yield return new WaitForSeconds(2f);
        antagonistSource.PlayOneShot(gunshot);
        yield return new WaitForSeconds(0.5f);
        antagonistSource.Stop();
        antagonistSource.PlayOneShot(gunshot);
        yield return new WaitForSeconds(0.5f);
        antagonistSource.Stop();
        antagonistSource.PlayOneShot(gunshot);
    }
}
