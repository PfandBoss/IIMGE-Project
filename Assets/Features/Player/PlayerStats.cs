using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private ReactiveProperty<int> health = new ReactiveProperty<int>(4);

    private int hiddenHealth = 100;
    [SerializeField]
    private ReactiveProperty<int> armor = new ReactiveProperty<int>(0);

    private int hiddenArmor = 0;
    [SerializeField]
    private ReactiveProperty<int> speedUp = new ReactiveProperty<int>(0);
    [SerializeField]
    private ReactiveProperty<int> dmgUp = new ReactiveProperty<int>(0);
    
    private ReactiveProperty<float> damageMultiplier = new ReactiveProperty<float>(1);
    private ReactiveProperty<float> speedMultiplier = new ReactiveProperty<float>(1);
    
    private bool coroutineStarted;

    private void Update()
    {
        //TODO: Implement speed in Player Movement and dmg multiplier in Fighting-System
        if (!coroutineStarted && (dmgUp.Value > 0 || speedUp.Value > 0) && MicrophoneInput.MicrophoneLoudness > 0.3)
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
        damageMultiplier.Value += dmgUp.Value * 0.5f;
        speedMultiplier.Value += speedUp.Value * 0.5f;
        speedUp.Value = 0;
        dmgUp.Value = 0;
        Debug.Log("dmg after use: " + damageMultiplier.Value);
        Debug.Log("speed after use: " + speedMultiplier.Value);

        yield return new WaitForSeconds(5);
        damageMultiplier.Value = 1;
        speedMultiplier.Value = 1;
        coroutineStarted = false;
    }

    public void ApplyDamage(int damage)
    {
        if (armor.Value > 0)
        {
            hiddenArmor -= damage;
            armor.Value = Mathf.CeilToInt(hiddenArmor / 25.0f);
            return;
        }
        if (hiddenHealth > 1)
        {
            hiddenHealth -= damage;
            health.Value = Mathf.CeilToInt(hiddenHealth / 25.0f);
            Debug.Log("health.Value: "+health.Value+ " hiddenHealth: "+hiddenHealth);
            return;
        }
        hiddenHealth -= damage;
        health.Value = Mathf.CeilToInt(hiddenHealth / 25.0f);
        PlayerDefeated();
    }

    public ReactiveProperty<float> getDamageMultiplier()
    {
        return damageMultiplier;
    }
    
    public ReactiveProperty<float> getSpeedMultiplier()
    {
        return speedMultiplier;
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
        hiddenArmor += value;
        armor.Value += 1;
    }
    
    public ReactiveProperty<int> getArmor()
    {
        return armor;
    }

    public void PlayerDefeated()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SceneManager.LoadScene("Game Over");
    }
}
