using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItems : MonoBehaviour
{
    public static GameItems _instance;
    // Use this for initialization
    void Awake()
    {
        _instance = this;
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
}
