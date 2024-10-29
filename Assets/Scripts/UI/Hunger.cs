using UnityEngine;

public class Hunger : ConditionUI
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        Hungry();
    }

    private void Hungry()
    {
        curValue -= passiveValue*Time.deltaTime;
    }

    public void Eat(float value)
    {
        curValue += value;
    }
}
