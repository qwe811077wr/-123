using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private PlayerMove move;
    private Animation anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animation>();
        move = GetComponent<PlayerMove>();
    }
    void LateUpdate()
    {
        if (move.state == PlayerState.Moving)
        {
            PlayAnim("Run");
        }
        else if (move.state == PlayerState.Idle)
        {
            PlayAnim("Idle");
        }
    }
    void PlayAnim(string animName)
    {
        anim.CrossFade(animName);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
