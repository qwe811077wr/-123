using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItems : MonoBehaviour
{
    public static GameItems _instance;
    public TextAsset itemTextAsset;
    private Dictionary<int, ObjectItem> items = new Dictionary<int, ObjectItem>();
    // Use this for initialization
    void Awake()
    {
        _instance = this;
        LoadItems();
    }
    void LoadItems()
    {
        string text = itemTextAsset.text;
        string[] strArray = text.Split('\n');
        for (int i = 0; i < strArray.Length; i++)
        {
            string[] proArray = strArray[i].Split(',');
            int id = int.Parse(proArray[0]);
            string name = proArray[1];
            string icon_name = proArray[2];
            ObjectType type = (ObjectType)int.Parse(proArray[3]);
            int hp = 0;
            int mp = 0;
            int price_sell = 0;
            int price_buy = 0;
            if (type == ObjectType.Drug)
            {
                hp = int.Parse(proArray[4]);
                mp = int.Parse(proArray[5]);
                price_sell = int.Parse(proArray[6]);
                price_buy = int.Parse(proArray[7]);
            }
            ObjectItem item = new ObjectItem(id, name, icon_name, type, hp, mp, price_sell, price_buy);
            items.Add(id, item);
        }
    }
    public ObjectItem GetItemById(int id)
    {
        if (items.ContainsKey(id))
        {
            return items[id];
        }
        return null;
    }
}
public enum ObjectType
{
    Drug,
    Equip,
    Mat
}
public class ObjectItem
{
    public int id;
    public string name;
    public string icon_name;
    public ObjectType type;
    public int hp;
    public int mp;
    public int price_sell;
    public int price_buy;
    public ObjectItem(int _id, string _name, string _icon_name,
                    ObjectType _type, int _hp, int _mp,
                    int _price_sell, int _price_buy)
    {
        id = _id;
        name = _name;
        icon_name = _icon_name;
        type = _type;
        hp = _hp;
        mp = _mp;
        price_sell = _price_sell;
        price_buy = _price_buy;
    }
}
