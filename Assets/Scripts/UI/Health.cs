public class Health : ConditionUI
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    public void Heal(float value)
    {
        curValue += value;
    }

    public void GetDamage(float value)
    {
        curValue -= value;
    }

}