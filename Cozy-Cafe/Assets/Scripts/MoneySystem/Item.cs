using Ruinum.Utils;
using UnityEngine;


public class Item : AnimationObject
{
    [SerializeField] private ItemSO itemSO;

    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void OnMouseDown()
    {
        gameObject.layer = 2;
    }

    private void OnMouseDrag()
    {
        transform.position = new Vector3(MouseUtils.GetMouseWorld2DPosition().x, MouseUtils.GetMouseWorld2DPosition().y, transform.position.z);
    }

    private void OnMouseUp()
    {
        if (!MouseUtils.TryRaycast2DToMousePosition(out var raycastHit2D)) { RefreshSettings(); return; }
        if (raycastHit2D.collider.TryGetComponent<CraftObject>(out var craftObject))
        {
            craftObject.AddItem(itemSO);

            AnimationPunch();

            MoneySystem.Singleton.SubtractAmount(itemSO);
        }

        if (raycastHit2D.collider.TryGetComponent<Customer>(out var customer))
        {
            customer.task.AddItem(itemSO);

            AnimationPunch();

            MoneySystem.Singleton.SubtractAmount(itemSO);
        }

        RefreshSettings();
    }

    private void RefreshSettings()
    {
        transform.position = _startPosition;
        gameObject.layer = 0;
    }
}
