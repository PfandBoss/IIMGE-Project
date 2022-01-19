using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassBar : MonoBehaviour
{
    public float BarRange => barRange;
    [SerializeField] private float barRange = 120;
    [SerializeField] private GameObject _targetImage;
    [SerializeField] private Sprite _img;

    public RectTransform BarRectTransform => _rectTransform;
    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void ChangeTargetImage()
    {
        _targetImage.GetComponent<Image>().sprite = _img;
    }
}