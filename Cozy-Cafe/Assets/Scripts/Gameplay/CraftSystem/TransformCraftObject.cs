using UnityEngine;


public class TransformCraftObject : MonoBehaviour
{
    [SerializeField] private Transform _transformPosition;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponentInObject<CraftObject>(out var craftObject))
        {
            craftObject.transform.position = _transformPosition.position;
        }
    }
}
