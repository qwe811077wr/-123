using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : UIDragDropItem
{
    int id = 0;
    private UISprite icon;
    protected override void Awake()
    {
        base.Awake();
        icon = GetComponent<UISprite>();
    }
    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
        if (surface != null)
        {
            print(surface.gameObject.tag);
        }
    }
    public void SetId(int _id)
    {
        id = _id;
        ObjectItem item = GameItems._instance.GetItemById(id);
        icon.spriteName = item.icon_name;
    }
}
