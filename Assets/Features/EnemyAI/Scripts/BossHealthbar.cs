using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

/*
 * Boss Healthbar Script
 */
public class BossHealthbar : MonoBehaviour
{
    public float LerpSpeed;
    public Animator Animator;

    private bool m_Die;
    private Image m_Healthbar;
    private float m_HealthPercentage = 1f;
    public EnemyAI EnemyAI;
    public GameObject CompassBar;

    private bool instantiated = false;


    private void Start()
    {
        m_Healthbar = GetComponent<Image>();
        EnemyAI.getHealth().Subscribe(i => SetHealth(i));
    }

    //If Boss died, lerp its health to 0
    void Update()
    {
        if(instantiated)
            m_Healthbar.fillAmount = Mathf.Lerp(m_Healthbar.fillAmount, m_HealthPercentage, Time.deltaTime * LerpSpeed);
    }

    public void Die()
    {
        m_Die = true;
        StartCoroutine(Hide());
    }

    //After Lerping health to 0, hide healthbar again
    IEnumerator Hide()
    {
        yield return new WaitForSeconds(3f);
        Animator.SetBool("Show", false);
        enabled = false;
        CompassBar.SetActive(true);
    }

    public void Show()
    {
        CompassBar.SetActive(false);
        Animator.SetBool("Show", true);
    }

    public void SetHealth(int health)
    {
        m_HealthPercentage = (100f/500f * health)/100f;
        if (m_HealthPercentage <= 0f)
        {
            Die();
        }
    }

    public void Instantiate()
    {
        instantiated = true;
        Show();
        EnemyAI.getHealth().Subscribe(i => SetHealth(i));
    }
}