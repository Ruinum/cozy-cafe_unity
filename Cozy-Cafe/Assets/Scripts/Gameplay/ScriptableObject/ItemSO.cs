using UnityEngine;

[CreateAssetMenu(fileName = nameof(ItemSO), menuName = EditorConstants.Data + nameof(ItemSO))]
public class ItemSO : ScriptableObject
{
    public string Name;
    public GameObject Prefab;
    public int Cost;
}
