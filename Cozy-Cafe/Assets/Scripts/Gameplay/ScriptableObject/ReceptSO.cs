using UnityEngine;

[CreateAssetMenu(fileName = nameof(ReceptSO), menuName = EditorConstants.Data + nameof(ReceptSO))]
public class ReceptSO : ScriptableObject
{
    public string Name;
    public ItemSO RequestItem;
    public ItemSO ResultItem;
}