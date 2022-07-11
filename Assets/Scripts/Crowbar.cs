using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class Crowbar : MonoBehaviour
{
    [SerializeField] private Canvas pryScreen;
    [SerializeField] private Canvas choiceScreen;
    [SerializeField] private PlayableDirector cutscene;
    [SerializeField] CinemachineVirtualCamera camera1;
    [SerializeField] CinemachineVirtualCamera camera2;

    [SerializeField] Light lightAdjust;
    //add music trigger here
    private void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.GetComponent<PryDoor>())
            {
                if (Vector3.Distance(hit.transform.position, Camera.main.transform.position) > 2.5f) return;
                pryScreen.enabled = true;
            }
            else
            {
                pryScreen.enabled = false;
            }
        }
    }
    public void UseItem()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.GetComponent<PryDoor>())
            {
                if (Vector3.Distance(hit.transform.position, Camera.main.transform.position) > 2.5f) return;
                hit.transform.gameObject.GetComponent<PryDoor>().AttemptPrying();
                SubtitleController subtitleController = FindObjectOfType(typeof(SubtitleController)) as SubtitleController;
                subtitleController.AttemptPryingCage();
                lightAdjust.GetComponent<LightAdjust>().SetLastTrigger(true);
                PlayCutscene();
            }
        }
    }

    private void PlayCutscene()
    {
        camera1.enabled = true;
        camera2.enabled = true;
        cutscene.enabled = true;
        SubtitleController subtitleController = FindObjectOfType(typeof(SubtitleController)) as SubtitleController;
        subtitleController.EvilGuyWalksIn();
        StartCoroutine(ChoiceTimer());
    }

    private IEnumerator ChoiceTimer()
    {
        yield return new WaitForSeconds(9f);
        SubtitleController subtitleController = FindObjectOfType(typeof(SubtitleController)) as SubtitleController;
        subtitleController.MakeYourChoice();
        choiceScreen.enabled = true;
    }
    void LateUpdate()
    {
        if (choiceScreen.enabled)
        {
            Cursor.visible = (choiceScreen.gameObject.activeInHierarchy || choiceScreen.gameObject.activeInHierarchy);
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
    public void DisableChoiceScreen()
    {
        choiceScreen.enabled = false;
    }
}
