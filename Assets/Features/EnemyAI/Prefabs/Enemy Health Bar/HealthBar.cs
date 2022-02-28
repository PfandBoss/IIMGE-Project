using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient Gradient;
    public Image fill;
    public EnemyAI EnemyAI;

    private void Start()
    {
        EnemyAI.getHealth().Subscribe(i => SetHealth(i));
    }
    
    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = Gradient.Evaluate(slider.normalizedValue);
    }
}