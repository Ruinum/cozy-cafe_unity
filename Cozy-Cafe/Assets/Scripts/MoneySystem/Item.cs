using UnityEngine;


public class Item : AnimationObject, IInteractable
{
    [SerializeField] private ItemSO itemSO;

    public void LeftMouseInteract()
    {
        MoneySystem.Singleton.SubtractAmount(itemSO);
        CraftSystem.Singleton.TryAddItem(itemSO);
        
        AnimationPunch();
    }

    public void RightMouseInteract()
    {
    }
}
