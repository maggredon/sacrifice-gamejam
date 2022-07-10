using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggered : MonoBehaviour
{
    bool triggered;
    private void OnTriggerEnter(Collider other)
    {
        triggered = true;
    }

    public bool GetTriggered()
    {
        return triggered;
    }
}
