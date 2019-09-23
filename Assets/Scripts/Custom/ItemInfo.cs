using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public static ItemInfo _instance;
    private UILabel label;
    private float timer = 0;
    void Awake()
    {
        _instance = this;
        label = this.GetComponentInChildren<UILabel>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            transform.position = UICamera.currentCamera.ScreenToWorldPoint(Input.mousePosition);
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void Show(int id)
    {
        gameObject.SetActive(true);
        timer = 2f;
        transform.position = UICamera.currentCamera.ScreenToWorldPoint(Input.mousePosition);
        ObjectItem info = GameItems._instance.GetItemById(id);
        string des = "";
        switch (info.type)
        {
            case ObjectType.Drug:
                des = GetDrugDes(info);
                break;
        }
        label.text = des;
    }
    public string GetDrugDes(ObjectItem info)
    {
        string str = "";
        str += "名称:" + info.name + "\n";
        str += "HP:" + info.hp.ToString() + "\n";
        str += "MP:" + info.mp.ToString() + "\n";
        str += "出售价格:" + info.price_sell.ToString();
        return str;
    }
}
