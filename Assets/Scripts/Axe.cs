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
}
