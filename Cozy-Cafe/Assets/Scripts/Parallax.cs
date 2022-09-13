using UnityEngine;
using Ruinum.Core;

public class Parallax : MonoBehaviour, IExecute
{
    [Header("Parameters")]
    [SerializeField] float offset;
    [SerializeField] float speed;

    private Vector2 _startPos;

    private void Start()
    {
        GameManager.Singleton.AddExecuteObject(this);
        _startPos = transform.position;
    }

    public void Execute()
    {
        Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float posX = Mathf.Lerp(transform.position.x, _startPos.x + (mousePos.x * offset), speed * Time.deltaTime);
        float posY = Mathf.Lerp(transform.position.y, _startPos.y + (mousePos.y * offset), speed * Time.deltaTime);

        transform.position = new Vector2(posX, posY);
    }
}
