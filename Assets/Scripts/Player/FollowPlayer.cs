using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;
    private Vector3 offsetPosition;
    public float distance = 0;
    public float scrollSpeed = 1;
    public float rotateSpeed = 1;
    private bool isRotating = false;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        transform.LookAt(player.position);
        offsetPosition = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offsetPosition + player.position;
        // 处理视野旋转
        RotateView();
        // 视野拉近拉远
        ScrollView();
    }
    void ScrollView()
    {
        // 向后=>负值 拉远
        distance = offsetPosition.magnitude;
        distance += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        offsetPosition = offsetPosition.normalized * distance;
    }
    void RotateView()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRotating = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }
        if (isRotating)
        {
            Vector3 origalPos = transform.position;
            Quaternion origalRotate = transform.rotation;
            transform.RotateAround(player.position, player.up, rotateSpeed * Input.GetAxis("Mouse X"));
            transform.RotateAround(player.position, -transform.right, rotateSpeed * Input.GetAxis("Mouse Y"));
            float x = transform.eulerAngles.x;
            if (x < 10 || x > 80)
            {
                transform.position = origalPos;
                transform.rotation = origalRotate;
            }
        }
        offsetPosition = transform.position - player.position;
    }
}
