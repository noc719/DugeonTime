using UnityEngine;

public class Health : Condition
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        if (CharacterManager.Instance.Player.ConditionUI.hunger.Hungry())
        {
            Starve();
        }
    }
    
    private void Starve()
    {
        if (curValue >= 0)
        {
            Substract(passiveValue * Time.deltaTime);
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {

    }

    public void Heal(float value)
    {
        Add(value);
    }

    public void GetDamage(float value)
    {
        Substract(value);
    }

}