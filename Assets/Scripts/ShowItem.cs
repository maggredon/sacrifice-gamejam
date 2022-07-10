using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShowItem : MonoBehaviour
{
    [NonSerialized] public List<string> pickedUpItems = new List<string>();
    [SerializeField] GameObject axe;
    [SerializeField] GameObject crowbar;
    [SerializeField] Canvas axeScreen;
    [SerializeField] Canvas crowbarScreen;
    bool axeAvailable;
    bool crowbarAvailable;
    bool axeSelected;
    bool crowbarSelected;

    private void Start()
    {
        axe.GetComponent<MeshRenderer>().enabled = false;
        crowbar.GetComponent<MeshRenderer>().enabled = false;
    }
    void Update()
    {
        ToggleSelectedItem();
        CheckForAvailableItem();
    }
    public void CheckForAvailableItem()
    {
        foreach (string item in pickedUpItems)
        {
            if (item == "Axe")
            {
                axeAvailable = true;
            }
            if (item == "Crowbar")
            {
                crowbarAvailable = true;
            }
        }
    }
    public void AddItem(string name)
    {
        pickedUpItems.Add(name);
        if (name == "Axe")
        {
            axeScreen.enabled = true;
            SubtitleController subtitleController = FindObjectOfType(typeof(SubtitleController)) as SubtitleController;
            subtitleController.FindAxe();
        }
        if (name == "Crowbar")
        {
            crowbarScreen.enabled = true;
            SubtitleController subtitleController = FindObjectOfType(typeof(SubtitleController)) as SubtitleController;
            subtitleController.FindCrowbar();
        }
    }
    public void OnSelectCrowbar(InputValue value)
    {
        if (crowbarScreen.enabled) crowbarScreen.enabled = false;

        if (crowbarAvailable)
        {
            crowbarSelected = true;
            axeSelected = false;
        }
    }
    public void OnSelectAxe(InputValue value)
    {
        if (axeScreen.enabled) axeScreen.enabled = false;

        if (axeAvailable)
        {
            axeSelected = true;
            crowbarSelected = false;
        }
    }
    private void ToggleSelectedItem()
    {
        if (axeSelected)
        {
            axe.GetComponent<MeshRenderer>().enabled = true;
            axe.GetComponent<Axe>().enabled = true;
        }
        else
        {
            axe.GetComponent<MeshRenderer>().enabled = false;
            axe.GetComponent<Axe>().enabled = false;
        }

        if (crowbarSelected)
        {
            crowbar.GetComponent<MeshRenderer>().enabled = true;
            crowbar.GetComponent<Crowbar>().enabled = true;
        }
        else
        {
            crowbar.GetComponent<MeshRenderer>().enabled = false;
            crowbar.GetComponent<Crowbar>().enabled = false;
        }
    }
}