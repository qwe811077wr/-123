using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public static Status _instance;
    private TweenPosition tween;
    private bool isShow = false;
    [SerializeField]
    private UILabel attackLabel;
    [SerializeField]
    private UILabel defLabel;
    [SerializeField]
    private UILabel speedLabel;
    [SerializeField]
    private UILabel pointLabel;
    [SerializeField]
    private UILabel summaryLabel;
    [SerializeField]
    private GameObject attackBtn;
    [SerializeField]
    private GameObject defBtn;
    [SerializeField]
    private GameObject speedBtn;
    private PlayerStatus playerStatus;
    void Awake()
    {
        _instance = this;
        tween = GetComponent<TweenPosition>();
        playerStatus = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerStatus>();
    }
    public void TransformState()
    {
        if (!isShow)
        {
            UpdateView();
            tween.PlayForward();
            isShow = true;
        }
        else
        {
            tween.PlayReverse();
            isShow = false;
        }
    }
    void UpdateView()
    {
        attackLabel.text = playerStatus.attack.ToString() + '+' + playerStatus.attack_plus.ToString();
        defLabel.text = playerStatus.def.ToString() + '+' + playerStatus.def_plus.ToString();
        speedLabel.text = playerStatus.speed.ToString() + '+' + playerStatus.speed_plus.ToString();

        pointLabel.text = playerStatus.point_remain.ToString();

        summaryLabel.text = "伤害:" + (playerStatus.attack + playerStatus.attack_plus).ToString() + " " +
                            "防御:" + (playerStatus.def + playerStatus.def_plus).ToString() + " " +
                            "速度:" + (playerStatus.speed + playerStatus.speed_plus).ToString();
        if (playerStatus.point_remain > 0)
        {
            attackBtn.SetActive(true);
            defBtn.SetActive(true);
            speedBtn.SetActive(true);
        }
        else
        {
            attackBtn.SetActive(false);
            defBtn.SetActive(false);
            speedBtn.SetActive(false);
        }
    }
    public void OnAttackPlusClick()
    {
        if (playerStatus.AddAttackPoint())
        {
            UpdateView();
        }
    }
    public void OnDefPlusClick()
    {
        if (playerStatus.AddDefPoint())
        {
            UpdateView();
        }
    }
    public void OnSpeedPlusClick()
    {
        if (playerStatus.AddSpeedPoint())
        {
            UpdateView();
        }
    }
}
