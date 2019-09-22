using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagGrid : MonoBehaviour
{
    public int id = 0;
    private ObjectItem item = null;
    public int num = 0;
    private UILabel numLabel;
    // Use this for initialization
    void Start()
    {
        numLabel = GetComponentInChildren<UILabel>();
        numLabel.gameObject.SetActive(false);
    }
    public void SetId(int _id, int _num = 1)
    {
        id = _id;
        num = _num;
        item = GameItems._instance.GetItemById(_id);
        GameItem gameItem = GetComponentInChildren<GameItem>();
        gameItem.SetId(id);
        NumLabelView();
    }
    public void ClearItem()
    {
        id = 0;
        item = null;
        num = 1;
        numLabel.gameObject.SetActive(false);
    }
    public void PlusNumber(int _num = 1)
    {
        num += _num;
        NumLabelView();
    }
    private void NumLabelView()
    {
        if (num > 1)
        {
            numLabel.gameObject.SetActive(true);
            numLabel.text = num.ToString();
        }
        else
        {
            numLabel.gameObject.SetActive(false);
        }
    }
}
