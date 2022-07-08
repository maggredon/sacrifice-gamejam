using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    //true when the pin is down
    bool inLockedPos = true;

    [SerializeField] GameObject top;
    [SerializeField] GameObject bot;
    private void Start()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        transform.position = bot.transform.position;
    }

    private void OnMouseDown()
    {
        if (inLockedPos)
        {
            transform.position = top.transform.position;
        }
        else
        {
            //transform.position = bot.transform.position;
            StartCoroutine(startFall());
        }
        inLockedPos = !inLockedPos;
    }

    public IEnumerator startFall()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(0.8f);
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
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
