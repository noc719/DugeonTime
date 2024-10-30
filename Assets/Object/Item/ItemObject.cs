using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IInteractable
{
    public string GetPromptNameText();
    public string GetPromptDescriptionText();
    public void OnInteract();
}

public class ItemObject : MonoBehaviour,IInteractable
{
    public ItemData data;

    public string GetPromptNameText()
    {
        string text = $"{data.itemName}";
        return text;
    }

    public string GetPromptDescriptionText()
    {
        string text = $"{data.discription}";
        return text;
    }

    public void OnInteract()
    {
        CharacterManager.Instance.Player.itemData = data;
        CharacterManager.Instance.Player.addItem?.Invoke();
        Destroy(gameObject);
    }
}