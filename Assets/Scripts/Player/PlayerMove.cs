using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerState
{
    Moving,
    Idle
}

public class PlayerMove : MonoBehaviour
{

    public float speed = 4f;
    public PlayerState state = PlayerState.Idle;
    private PlayerDirction dirction;
    private CharacterController controller;
    public bool isMoving = false;
    // Use this for initialization
    void Start()
    {
        dirction = GetComponent<PlayerDirction>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(dirction.targetPostion, transform.position);
        if (distance > 0.1f)
        {
            isMoving = true;
            state = PlayerState.Moving;
            controller.SimpleMove(transform.forward * speed);
        }
        else
        {
            isMoving = false;
            state = PlayerState.Idle;
        }
    }
}
