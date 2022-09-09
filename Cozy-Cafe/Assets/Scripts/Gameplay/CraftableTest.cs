using UnityEngine;

public class CraftableTest : MonoBehaviour
{
    [SerializeField] private ItemSO _itemSO;
    [SerializeField] private CraftInteractable _craftInteractable;

    private void Start()
    {
        _craftInteractable.TryCraftItem(_itemSO);
    }
}