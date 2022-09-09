using UnityEngine;

public class CraftTest : MonoBehaviour
{
    [SerializeField] private ItemSO _itemSO;
    [SerializeField] private CraftInteractable _craftInteractable;

    private void Start()
    {
        _craftInteractable.TryCraftItem(_itemSO);
    }
}