using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;
    [SerializeField] private Image[] healthCanvas;
    [SerializeField] private Image[] armorCanvas;
    [SerializeField] private Image[] speedCanvas;
    [SerializeField] private Image[] dmgCanvas;
    [SerializeField] private Text dmgMulText;
    [SerializeField] private Text speedMulText;
    private void Awake()
    {
        stats.getHealth().Subscribe(i => UpdateUI(i, healthCanvas)).AddTo(this);
        stats.getArmor().Subscribe(i => ArmorUI(i)).AddTo(this);
        stats.getDmgUp().Subscribe(i => UpdateUI(i, dmgCanvas)).AddTo(this);
        stats.getSpeedUp().Subscribe(i => UpdateUI(i, speedCanvas)).AddTo(this);
        stats.getSpeedMultiplier().Subscribe(f => UpdateMultipliers(f, speedMulText));
        stats.getDamageMultiplier().Subscribe(f => UpdateMultipliers(f, dmgMulText));
    }

    private void UpdateUI(int value, Image[] canvas)
    {
        for (var i = 0; i < canvas.Length; i++)
        {
            canvas[i].gameObject.SetActive(false);
        }
        canvas[value].gameObject.SetActive(true);
    }
    
    private void HealthUI(int value)
    {
        value = Mathf.RoundToInt(value / 4.0f);
        for (var i = 0; i < armorCanvas.Length; i++)
        {
            armorCanvas[i].gameObject.SetActive(false);
        }

        if (value != 0)
        {
            armorCanvas[value - 1].gameObject.SetActive(true);
        }
    }
    
    private void ArmorUI(int value)
    {
        value /= 3;
        for (var i = 0; i < armorCanvas.Length; i++)
        {
            armorCanvas[i].gameObject.SetActive(false);
        }

        if (value != 0)
        {
            armorCanvas[value - 1].gameObject.SetActive(true);
        }
    }

    private void UpdateMultipliers(float multiplier, Text mulText)
    {
        Debug.Log("Multiplier");
        if (multiplier.Equals(1.0f))
        {
            mulText.gameObject.SetActive(false);
        }
        else
        {
            mulText.text = multiplier + "x";
            mulText.gameObject.SetActive(true);
        }
    }
}
