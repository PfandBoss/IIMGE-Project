using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    private ReactiveProperty<int> health = new ReactiveProperty<int>(4);
    private ReactiveProperty<int> armor = new ReactiveProperty<int>(0);
    private ReactiveProperty<int> speedUp = new ReactiveProperty<int>(0);
    private ReactiveProperty<int> dmgUp = new ReactiveProperty<int>(0);
    private int damage = 20;

    public void ApplyDamage(int damage)
    {
        if (armor.Value > 0)
        {
            armor.Value -= damage;
        }
        else if (health.Value > 0)
        {
            health.Value -= damage;
            PlayerDefeated();
        }
    }
    public void UpdateHealthValue(int value)
    {
        health.Value += value;
    }

    public ReactiveProperty<int> getHealth()
    {
        return health;
    }
    public void UpdateSpeedUpValue(int value)
    {
        speedUp.Value += value;
    }

    public ReactiveProperty<int> getSpeedUp()
    {
        return speedUp;
    }

    public void UpdateDmgUpValue(int value)
    {
        dmgUp.Value += value;
    }
    
    public ReactiveProperty<int> getDmgUp()
    {
        return dmgUp;
    }
    
    public void UpdateArmorCnt(int value)
    {
        armor.Value += value;
    }
    
    public ReactiveProperty<int> getArmor()
    {
        return armor;
    }

    public void PlayerDefeated()
    {
        SceneManager.LoadScene("Game Over");
    }
}
