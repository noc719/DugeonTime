using UnityEngine;

public class Hunger : Condition
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        if (curValue > 0)
        {
            Substract(passiveValue*Time.deltaTime);
        }
    }

    public bool Hungry()
    {
        return (curValue == 0);
    }

    public void Eat(float value)
    {
        Add(value);
    }
}
