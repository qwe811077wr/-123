using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    public int hp = 100;
    public int mp = 100;
    private int coin = 200;
    public int level = 1;
    public int attack = 20;
    public int attack_plus = 0;
    public int def = 20;
    public int def_plus = 0;
    public int speed = 20;
    public int speed_plus = 0;
    public int point_remain = 0;
    public void AddCoin(int count)
    {
        coin += count;
    }
    public bool AddAttackPoint(int point = 1)
    {
        if (point_remain >= point)
        {
            point_remain -= point;
            attack_plus++;
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool AddDefPoint(int point = 1)
    {
        if (point_remain >= point)
        {
            point_remain -= point;
            def_plus++;
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool AddSpeedPoint(int point = 1)
    {
        if (point_remain >= point)
        {
            point_remain -= point;
            speed_plus++;
            return true;
        }
        else
        {
            return false;
        }
    }
}
