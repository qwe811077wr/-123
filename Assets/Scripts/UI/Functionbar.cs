using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functionbar : MonoBehaviour
{
    public void OnStatusBtnClick()
    {
        Status._instance.TransformState();
    }
    public void OnBagBtnClick()
    {
        BagMgr._instance.TransformState();
    }
    public void OnEquipBtnClick()
    {

    }
    public void OnSkillBtnClick()
    {

    }
    public void OnSettingBtnClick()
    {

    }
}
