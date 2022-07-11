using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] GameObject lockPick;
    [SerializeField] Light spotLight;
    bool finished = false;
    bool started = false;
    public void LookAtDoor()
    {
        if (finished) return;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Door")
            {
                if (Vector3.Distance(hit.transform.position, Camera.main.transform.position) > 3f) return;
                started = true;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        LookAtDoor();
        if(started)
        {
            spotLight.enabled = true;
            lockPick.SetActive(true);
            Cursor.visible = true;
            StartCoroutine(CheckFinish(GameObject.FindGameObjectWithTag("Door")));

        }
    }

    private IEnumerator HideLock()
    {
        yield return new WaitForSeconds(10f);
        spotLight.enabled = false;
        lockPick.SetActive(false);
    }

    private IEnumerator CheckFinish(GameObject hit)
    {
        yield return new WaitForSeconds(0.1f);
        if (lockPick.GetComponent<PinScript>().Unlocked())
        {
            Destroy(spotLight);
            hit.transform.Rotate(new Vector3(0, 80, 0));
            Destroy(lockPick);
            Destroy(GetComponent<DoorScript>());
            finished = true;
            Cursor.visible = false;
        }
    }
}
