using UnityEngine;
using Ruinum.Core;

public class Item : MonoBehaviour, IExecute
{
    [SerializeField]
    private ItemSO itemSO;

    private void Start()
    {
        GameManager.Singleton.AddExecuteObject(this);
    }

    public void Execute()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                MoneySystem.Singleton.SubtractAmount(itemSO);
            }
        }
    }
}
