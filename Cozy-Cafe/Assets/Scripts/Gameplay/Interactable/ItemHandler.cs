using UnityEngine;

public class ItemHandler : MonoBehaviour, IInteractable
{
    private ItemSO _item;

    public void SetItem(ItemSO item)
    {
        _item = item;
    }

    public void LeftMouseInteract()
    {
        //Add to inventory logic
    }

    public void RightMouseInteract()
    {
    }
}