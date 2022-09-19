using Ruinum.Utils;
using System.Collections.Generic;
using UnityEngine;

public class CraftObject : AnimationObject
{
    private List<ItemSO> _itemSOs = new List<ItemSO>();
    private List<ItemSO> _syrups = new List<ItemSO>();
    private List<ItemSO> _sprinkles = new List<ItemSO>();

    public void AddItem(ItemSO itemSO)
    {
        AnimationPunch();

        if (itemSO.IsSyrup) { _syrups.Add(itemSO); return; }
        if (itemSO.IsTopping) { _sprinkles.Add(itemSO); return; }

        _itemSOs.Add(itemSO);
    }

    private void OnMouseDrag()
    {
        transform.position = new Vector3(MouseUtils.GetMouseWorld2DPosition().x, MouseUtils.GetMouseWorld2DPosition().y, transform.position.z);
    }
}
