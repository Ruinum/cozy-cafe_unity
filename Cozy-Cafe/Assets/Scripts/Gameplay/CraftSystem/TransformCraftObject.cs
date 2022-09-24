using UnityEngine;


public class TransformCraftObject : MonoBehaviour
{
    [SerializeField] private Transform _transformPosition;
    [SerializeField] GameObject _hintCanvas;

    public void TransformObject(GameObject gameObject)
    {
        gameObject.transform.position = _transformPosition.position;
    }

    private void OnMouseEnter()
    {
        _hintCanvas.SetActive(true);
    }

    private void OnMouseExit()
    {
        _hintCanvas.SetActive(false);
    }
}
