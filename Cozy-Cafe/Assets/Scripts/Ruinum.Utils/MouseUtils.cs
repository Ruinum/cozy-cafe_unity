using UnityEngine;


namespace Ruinum.Utils
{
    public static class MouseUtils
    {
        public static Vector3 GetMouseWorldPosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, 999f))
            {
                return hit.point;
            }
            else return Vector3.zero;
        }

        public static bool TryRaycast2DToMousePosition(out RaycastHit2D raycastHit2D)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            raycastHit2D = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (raycastHit2D.collider != null) return true;

            return false;
        }
    }
}
