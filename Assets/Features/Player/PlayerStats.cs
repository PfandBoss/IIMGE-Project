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
    public int speedUp; //TODO: Change to subject and subscribe Item Trigger to it
    public int dmgUp; //TODO: Let UI Subscribe to subject and update itself when changed
    
    private ReactiveProperty<float> damageMultiplier = new ReactiveProperty<float>(1);
    private ReactiveProperty<float> speedMultiplier = new ReactiveProperty<float>(1);
    
    private bool coroutineStarted;

    private void Start()
    {
        health.Value -= 1;
    }

    private void Update()
    {
        //TODO: Implement speed in Player Movement and dmg multiplier in Fighting-System
        if (!coroutineStarted && (dmgUp > 0 || speedUp > 0) && MicrophoneInput.MicrophoneLoudness > 0.3)
        {
            Debug.Log(MicrophoneInput.MicrophoneLoudness);
            coroutineStarted = true;
            StopAllCoroutines();
            StartCoroutine(UseItems());
        }
    }

    private IEnumerator UseItems()
    {
        Debug.Log("dmg before use: " + damageMultiplier.Value);
        Debug.Log("speed before use: " + speedMultiplier.Value);
        damageMultiplier.Value += dmgUp;
        speedMultiplier.Value += speedUp;
        speedUp = 0;
        dmgUp = 0;
        Debug.Log("dmg after use: " + damageMultiplier.Value);
        Debug.Log("speed after use: " + speedMultiplier.Value);
        
        yield return new WaitForSeconds(20);
        damageMultiplier.Value = 1;
        speedMultiplier.Value = 1;
        coroutineStarted = false;
    }

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
        speedUp += value;
    }

    public int getSpeedUp()
    {
        return speedUp;
    }

    public void UpdateDmgUpValue(int value)
    {
        dmgUp += value;
    }
    
    public int getDmgUp()
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
