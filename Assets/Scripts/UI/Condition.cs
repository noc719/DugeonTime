using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    [Header("Value")]
    [SerializeField] protected float startValue;
    [SerializeField] protected float maxValue;
    [SerializeField] protected float passiveValue;
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

    public void Add(float value)
    {
        curValue = Mathf.Min(curValue + value, maxValue);
    }
    public void Substract(float value)
    {
        curValue = Mathf.Max(curValue - value, 0);
    }

    public float CurPercentage()
    {
        return curValue / maxValue;
    }
}
