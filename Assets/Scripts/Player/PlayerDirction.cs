using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirction : MonoBehaviour
{
    public GameObject effect_prefab;
    private bool isMoving = false;
    public Vector3 targetPostion = Vector3.zero;
    private PlayerMove playerMove;
    // Use this for initialization
    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        targetPostion = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && UICamera.hoveredObject.name == "UI Root")
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool isCollider = Physics.Raycast(ray, out hit);
            if (isCollider && hit.collider.tag == Tags.ground)
            {
                isMoving = true;
                LookAtTarget(hit.point);
                ShowClickEffect(hit.point);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
        }
        if (isMoving)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool isCollider = Physics.Raycast(ray, out hit);
            if (isCollider && hit.collider.tag == Tags.ground)
            {
                LookAtTarget(hit.point);
            }
        }
        else
        {
            if (playerMove.isMoving)
            {
                LookAtTarget(targetPostion);
            }
        }
    }
    void LookAtTarget(Vector3 position)
    {
        targetPostion = new Vector3(position.x, transform.position.y, position.z);
        transform.LookAt(targetPostion);
    }
    void ShowClickEffect(Vector3 hitPoint)
    {
        hitPoint = new Vector3(hitPoint.x, hitPoint.y + 0.1f, hitPoint.z);
        GameObject.Instantiate(effect_prefab, hitPoint, Quaternion.identity);
    }
}
