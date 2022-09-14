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

        public static bool TryRaycastToMousePosition(out RaycastHit raycastHit2D)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit2D, 999f))
            {
                return true;
            }

            return false;
        }
    }
}
