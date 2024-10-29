using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConditionUI : MonoBehaviour
{
    [Header("Value")]
    [SerializeField] protected float startValue;
    [SerializeField] protected float maxValue;
    [SerializeField] protected int passiveValue;
    protected float curValue;

    [Header("Bar")]
    [SerializeField] private Image bar;

    protected virtual void Start()
    {
        curValue = startValue;
    }

    protected virtual void Update()
    {
        bar.fillAmount = CurPercentage();
    }

    public float CurPercentage()
    {
        return curValue / maxValue;
    }
}
