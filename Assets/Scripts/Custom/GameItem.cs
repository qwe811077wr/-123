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
            if (surface.gameObject.tag == Tags.itemGrid)
            {
                if (surface != transform.parent.gameObject)
                {
                    BagGrid oldbagGrid = transform.parent.GetComponent<BagGrid>();
                    transform.parent = surface.transform;
                    BagGrid newbagGrid = surface.GetComponent<BagGrid>();
                    newbagGrid.SetId(oldbagGrid.id, oldbagGrid.num);
                    oldbagGrid.ClearItem();
                }
            }
            else if (surface.gameObject.tag == Tags.item)
            {
                BagGrid grid1 = transform.parent.GetComponent<BagGrid>();
                BagGrid grid2 = surface.transform.parent.GetComponent<BagGrid>();
                int id = grid1.id;
                int num = grid1.num;
                grid1.SetId(grid2.id, grid2.num);
                grid2.SetId(id, num);
            }
        }
        ResetPos();
    }
    private void ResetPos()
    {
        transform.localPosition = Vector3.zero;
    }
    public void SetId(int _id)
    {
        id = _id;
        ObjectItem item = GameItems._instance.GetItemById(id);
        icon.spriteName = item.icon_name;
    }
}
