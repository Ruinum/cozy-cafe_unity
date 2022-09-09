using UnityEngine;

[RequireComponent(typeof(CraftInteractable))]
public class CraftListener : MonoBehaviour
{
    [SerializeField] private Transform _prefabTransform;

    private CraftInteractable _craftInteractable;

    private void Start()
    {
        _craftInteractable = GetComponent<CraftInteractable>();
        _craftInteractable.AddListener(CreateVisual);
    }

    private void CreateVisual(ItemSO itemSO)
    {
        Instantiate(itemSO.Prefab, _prefabTransform);
    }
}