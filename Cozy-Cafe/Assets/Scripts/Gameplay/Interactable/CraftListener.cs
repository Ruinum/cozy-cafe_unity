using UnityEngine;


[RequireComponent(typeof(CraftInteractable))]
public class CraftListener : MonoBehaviour
{
    [SerializeField] private Transform _prefabTransform;

    private GameObject _visual;
    private CraftInteractable _craftInteractable;

    private void Start()
    {
        _craftInteractable = GetComponent<CraftInteractable>();
        _craftInteractable.AddListener(CreateVisual, DeleteVisual);
    }

    private void CreateVisual(ItemSO itemSO)
    {
        _visual = Instantiate(itemSO.Prefab, _prefabTransform);
        _visual.GetComponent<ItemHandler>().SetItem(itemSO);
    }

    private void DeleteVisual()
    {
        Destroy(_visual);
    }
}
