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
    public GameObject itemIcon;
    private int startPosX = -150;
    private int startPosY = 100;
    private int spacePosX = 75;
    private int spacePosY = 100;
    public int oneLineCount = 5;
    public int totalGridNum = 16;
    private bool isShow = false;
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
                GameObject grid = NGUITools.AddChild(gameObject, girdPrefab);
                grid.transform.localPosition = new Vector3(startPosX + j * spacePosX,
                                        startPosY - i * spacePosY, 0);
                bagGrids.Add(grid.GetComponent<BagGrid>());
            }
        }
    }
    public void PickUp(int id)
    {
        BagGrid grid = FindGridById(id);
        if (grid == null)
        {
            grid = FindEmptyGrid();
            if (grid != null)
            {
                GameObject itemGo = NGUITools.AddChild(grid.gameObject, itemIcon);
                itemGo.transform.localPosition = Vector3.zero;
                itemGo.GetComponent<UISprite>().depth = 8;
                grid.SetId(id);
            }
        }
        else
        {
            grid.PlusNumber();
        }
    }
    public BagGrid FindGridById(int id)
    {
        for (int i = 0; i < bagGrids.Count; i++)
        {
            if (bagGrids[i].id == id)
            {
                return bagGrids[i];
            }
        }
        return null;
    }
    public BagGrid FindEmptyGrid()
    {
        for (int i = 0; i < bagGrids.Count; i++)
        {
            if (bagGrids[i].id == 0)
            {
                return bagGrids[i];
            }
        }
        return null;
    }
    void Show()
    {
        isShow = true;
        tween.PlayForward();
    }
    void Hide()
    {
        isShow = false;
        tween.PlayReverse();
    }

    public void TransformState()
    {
        if (isShow == false)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            PickUp(Random.Range(1001, 1004));
        }
    }
}
