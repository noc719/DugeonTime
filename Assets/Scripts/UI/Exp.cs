public class Exp : Condition
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    public void GetExp(float value)
    {
        if(curValue > maxValue)
        {
            //레벨업 일단 희망 구현 사항
        }
        curValue += value;
    }
}