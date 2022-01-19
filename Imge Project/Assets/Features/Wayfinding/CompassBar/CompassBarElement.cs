using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UIElements;

public class CompassBarElement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform target;
    [SerializeField] private bool useFixDirection = false;
    [SerializeField] private Vector3 fixDirection;
    [SerializeField] private Image CompassBarImage;

    private CompassBar bar;
    private RectTransform _rectTransform;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        bar = GetComponentInParent<CompassBar>();
    }

    private void Update()
    {
        float angle;
        if (useFixDirection)
        {
            angle = Vector3.SignedAngle(player.forward, fixDirection, Vector3.up);
        }
        else
        {
            var dirVec = target.position - player.position;
            angle = Vector2.SignedAngle(new Vector2(player.forward.x, player.forward.z), new Vector2(dirVec.x, dirVec.z));
        }

        var mappedAngle = angle / 180f;
        
        float xPosition = -mappedAngle * (360 / bar.BarRange) * (bar.BarRectTransform.rect.width / 2);

        _rectTransform.anchoredPosition = new Vector2(xPosition, _rectTransform.anchoredPosition.y);
    }

    public void ChangeTarget(Transform target_p)
    {
        target = target_p;
    }
}