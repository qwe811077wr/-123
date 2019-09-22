using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagMgr : MonoBehaviour
{
    public static BagMgr _instance;
    private TweenPosition tween;
    public List<BagGrid> bagGrids = new List<BagGrid>();
    private int coinCount = 1000;
    public UILabel coinLabel;
    public GameObject girdPrefab;
    private int startPosX = -150;
    private int startPosY = 100;
    private int spacePosX = 75;
    private int spacePosY = 100;
    public int oneLineCount = 5;
    public int totalGridNum = 16;
    void Awake()
    {
        _instance = this;
        tween = GetComponent<TweenPosition>();
        InitGrids();
    }
    void InitGrids()
    {
        for (int i = 0; i < totalGridNum / oneLineCount; ++i)
        {
            for (int j = 0; j < oneLineCount; j++)
            {
                GameObject go = GameObject.Instantiate(girdPrefab, Vector3.zero, Quaternion.identity);
                go.transform.parent = gameObject.transform;
                go.transform.localPosition = new Vector3(startPosX + j * spacePosX,
                                        startPosY - i * spacePosY, 0);
                go.transform.localScale = Vector3.one;
                bagGrids.Add(go.GetComponent<BagGrid>());
            }
        }
    }
    public void Show()
    {
        tween.PlayForward();
    }
    public void Hide()
    {
        tween.PlayReverse();
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
