using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClickToMove : MonoBehaviour
{
    //true when the pin is down
    bool inLockedPos = true;
    bool falling = false;
    [SerializeField] GameObject top;
    [SerializeField] GameObject bot;
    [SerializeField] GameObject clickCounter;
    GameObject[] pins;
    private void Start()
    {
        StartCoroutine(startFall());
        pins = clickCounter.GetComponent<Combination>().GetListPins();
    }

    private void OnMouseDown()
    {
        if (inLockedPos)
        {
            int pos1, pos2;
            transform.position = top.transform.position;
            clickCounter.GetComponent<Combination>().GetArrayPoss(transform.name, out pos1, out pos2);
            if (pos1.ToString() != transform.name)
            {
                pins[pos1].GetComponent<ClickToMove>().TriggerFall();
            }
            if (pos2.ToString() != transform.name)
            {
                pins[pos2].GetComponent<ClickToMove>().TriggerFall();
            }
        }
        else
        {
            if (!falling)
            {
                StartCoroutine(startFall());
            }
            
        }
        inLockedPos = !inLockedPos;
    }

    public IEnumerator startFall()
    {
        falling = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        falling = false;
    }

    public void TriggerFall()
    {
        inLockedPos = true;
        StartCoroutine(startFall());
    }

    public bool GetInLockedPos()
    {
        return inLockedPos;
    }
}
