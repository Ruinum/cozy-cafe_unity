using UnityEngine;

[CreateAssetMenu(fileName = nameof(ItemSO), menuName = EditorConstants.Data + nameof(ItemSO))]
public class ItemSO : ScriptableObject
{
    public string Name;
    [TextArea(5,5)]
    public string Description;
}
