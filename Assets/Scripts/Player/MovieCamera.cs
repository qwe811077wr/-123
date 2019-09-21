using UnityEngine;
using System.Collections;

public class MovieCamera : MonoBehaviour
{

    public float speed = 10;

    private float endZ = -20;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 还没有达到目标位置，需要移动
        if (transform.position.z < endZ)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
