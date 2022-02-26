using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public Item_Type type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            PlayerStats stats = other.GetComponent<PlayerStats>();
            switch (type)
            {  
                case Item_Type.DmgUP:
                    if (stats.getDmgUp() < 3)
                    {
                        stats.UpdateDmgUpValue(1);
                        Destroy(gameObject);
                    }
                    break;
                case Item_Type.SpeedUP:
                    if (stats.getSpeedUp() < 3)
                    {
                        stats.UpdateSpeedUpValue(1);
                        Destroy(gameObject);
                    }
                    break;
                case Item_Type.ArmorUP:
                    if (stats.getArmor().Value < 3)
                    {
                        stats.UpdateArmorCnt(1);
                        Destroy(gameObject);
                    }
                    break;
            }
        }
    }
}

public enum Item_Type
{
    DmgUP,
    ArmorUP,
    SpeedUP
}
