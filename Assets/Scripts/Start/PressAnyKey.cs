using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKey : MonoBehaviour
{

    private bool isKeyDown = false;
    private GameObject buttonContainer;
    // Use this for initialization
    void Start()
    {
        buttonContainer = this.transform.parent.Find("buttonContainer").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isKeyDown == false)
        {
            if (Input.anyKey)
            {
                ShowButton();
            }
        }
    }
    void ShowButton()
    {
        buttonContainer.SetActive(true);
        this.gameObject.SetActive(false);
        isKeyDown = true;
    }
}
