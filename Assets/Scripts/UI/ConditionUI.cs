using UnityEngine;

public class ConditionUI : MonoBehaviour
{
    public Health health;
    public  Hunger hunger;
    public Exp exp;

    private void Start()
    {
        CharacterManager.Instance.Player.ConditionUI = this;
        health = GetComponentInChildren<Health>();
        hunger = GetComponentInChildren<Hunger>();
        exp = GetComponentInChildren<Exp>();
    }
}