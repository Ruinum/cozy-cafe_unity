using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] float offset;
    [SerializeField] float speed;

    private Vector2 _startPos;

    private void Start() => _startPos = transform.position;

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float posX = Mathf.Lerp(transform.position.x, _startPos.x + (mousePos.x * offset), speed * Time.deltaTime);
        float posY = Mathf.Lerp(transform.position.y, _startPos.y + (mousePos.y * offset), speed * Time.deltaTime);

        transform.position = new Vector2(posX, posY);
    }
}
