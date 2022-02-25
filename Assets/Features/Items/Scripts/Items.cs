using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public Item_Type type;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.Equals(Player))
        {
            switch (type)
            {
                case Item_Type.DmgUP: 
                    Player.GetComponent<PlayerStats>().UpdateArmorCnt(1);
                    break;
                case Item_Type.SpeedUP:
                    Player.GetComponent<PlayerStats>().UpdateSpeedUpValue(1);
                    break;
                case Item_Type.ArmorUP:
                    Player.GetComponent<PlayerStats>().UpdateArmorCnt(1);
                    break;
            }
            Destroy(this);
        }
    }
}

public enum Item_Type
{
    DmgUP,
    ArmorUP,
    SpeedUP
}
