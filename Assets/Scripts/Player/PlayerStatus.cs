using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    public int hp = 100;
    public int mp = 100;
    private int coin = 200;
    public int level = 1;
    public void AddCoin(int count)
    {
        coin += count;
    }
}
