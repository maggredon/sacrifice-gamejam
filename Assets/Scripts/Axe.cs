using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Axe : MonoBehaviour
{
    [SerializeField] Animator axeAnimator;
    private void Start()
    {
        GetComponent<BoxCollider>().enabled = false;
    }
    public void UseItem()
    {
        GetComponent<BoxCollider>().enabled = true;
        axeAnimator.SetBool("Attack", true);
    }
    public void StopAnimation()
    {
        GetComponent<BoxCollider>().enabled = false;
        axeAnimator.SetBool("Attack", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (axeAnimator.GetBool("Attack"))
        {
            if (other.GetComponent<AppearItemOnBreak>())
            {
                other.GetComponent<AppearItemOnBreak>().DestroyObject();
            }
        }
    }

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
}
