using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinScript : MonoBehaviour
{
    //script for checking all of the pins
    List<ClickToMove> pins = new List<ClickToMove>();
    bool completed;
    void Start()
    {
        foreach (ClickToMove pin in gameObject.GetComponentsInChildren<ClickToMove>())
        {
            pins.Add(pin);
        }
    }

    public bool Unlocked()
    {
        completed = true;
        int i = 1;
        foreach (ClickToMove pin in pins)
        {
            Debug.Log(i + "" + pin.GetInLockedPos());
            i++;
            if (pin.GetInLockedPos() == true)
            {
                completed = false;
                break;
            }
        }
        return completed;
    }

}
