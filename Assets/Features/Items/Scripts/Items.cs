using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class Items : MonoBehaviour
{
    public Item_Type type;
    private bool hasCollide;

    private void Awake()
    {
        this.OnTriggerEnterAsObservable().Subscribe(collider1 => pickUpItem(collider1));
    }

    private void pickUpItem(Collider other)
    {
        if (hasCollide == false)
        {
            hasCollide = true;
            PlayerStats stats = other.GetComponent<PlayerStats>();
            Debug.Log(other.gameObject.name);
            switch (type)
            {
                case Item_Type.DmgUP:
                    if (stats.getDmgUp().Value < 3)
                    {
                        stats.UpdateDmgUpValue(1);
                        Destroy(gameObject.transform.parent.gameObject);
                        Destroy(gameObject);
                    }

                    break;
                case Item_Type.SpeedUP:
                    if (stats.getSpeedUp().Value < 3)
                    {
                        stats.UpdateSpeedUpValue(1);
                        Destroy(gameObject.transform.parent.gameObject);
                        Destroy(gameObject);
                    }

                    break;
                case Item_Type.ArmorUP:
                    if (stats.getArmor().Value < 3)
                    {
                        stats.UpdateArmorCnt(1);
                        Destroy(gameObject.transform.parent.gameObject);
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
