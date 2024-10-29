using UnityEngine;

public class Player: MonoBehaviour
{
    public PlayerController controller;
    public ConditionUI ConditionUI;
    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        ConditionUI = GetComponent<ConditionUI>();
    }
}