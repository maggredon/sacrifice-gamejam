using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Axe : MonoBehaviour
{
    [SerializeField] Animator axeAnimator;
    public void UseItem()
    {
        axeAnimator.SetBool("Attack", true);
    }
    public void StopAnimation()
    {
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
