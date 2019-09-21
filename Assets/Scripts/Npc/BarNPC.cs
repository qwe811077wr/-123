using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarNPC : Npc
{
    public TweenPosition questTween;
    public bool isInTask = false;
    public int killCount = 0;
    public int needCount = 10;
    public int rewardCoin = 1000;
    public UILabel desLabel;
    public GameObject acceptBtnGo;
    public GameObject okBtnGo;
    public GameObject cancelBtnGo;
    private PlayerStatus status;
    void Start()
    {
        status = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerStatus>();
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isInTask)
            {
                ShowTaskProgress();
            }
            else
            {
                ShowTask();
            }
            ShowQuest();
        }
    }

    void ShowQuest()
    {
        questTween.gameObject.SetActive(true);
        questTween.PlayForward();
    }
    void HideQuest()
    {
        questTween.PlayReverse();
    }

    void ShowTask()
    {
        desLabel.text = "任务:\n杀死" + needCount.ToString() + "只小野狼\n" +
                        "奖励:\n" + rewardCoin.ToString() + "金币";
        okBtnGo.SetActive(false);
        acceptBtnGo.SetActive(true);
        cancelBtnGo.SetActive(true);
    }
    void ShowTaskProgress()
    {
        desLabel.text = "任务:\n你已经杀死了" + killCount.ToString() + "/" + needCount.ToString() + "只小野狼\n" +
                        "奖励:\n" + rewardCoin.ToString() + "金币";
        okBtnGo.SetActive(true);
        acceptBtnGo.SetActive(false);
        cancelBtnGo.SetActive(false);
    }

    public void OnCloseButtonClick()
    {
        HideQuest();
    }

    public void OnAcceptButtonClick()
    {
        ShowTaskProgress();
        isInTask = true;
    }

    public void OnOkButtonClick()
    {
        if (killCount >= needCount)
        {
            status.AddCoin(rewardCoin);
        }
        else
        {
            HideQuest();
        }
    }

    public void OnCancelButtonClick()
    {
        HideQuest();
    }
}
