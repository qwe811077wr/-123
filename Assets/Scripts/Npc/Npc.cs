using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    private void OnMouseEnter()
    {
        CursorManager._instance.SetNpcTalk();
    }
    private void OnMouseExit()
    {
        CursorManager._instance.SetNormal();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
