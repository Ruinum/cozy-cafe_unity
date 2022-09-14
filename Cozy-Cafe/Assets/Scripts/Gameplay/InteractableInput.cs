using Ruinum.Core;
using Ruinum.Utils;

using UnityEngine;


public class InteractableInput : Executable
{
    public override void Execute()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseUtils.TryRaycastToMousePosition(out var raycastHit);
            raycastHit.collider.GetComponent<IInteractable>().LeftMouseInteract();
        }

        if (Input.GetMouseButtonDown(1))
        {
            MouseUtils.TryRaycastToMousePosition(out var raycastHit);
            raycastHit.collider.GetComponent<IInteractable>().RightMouseInteract();
        }
    }
}
