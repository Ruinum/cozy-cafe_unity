using Ruinum.Core;
using Ruinum.Utils;

using UnityEngine;


public class InteractableInput : Executable
{
    public override void Execute()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!MouseUtils.TryRaycast2DToMousePosition(out var raycastHit)) return;


            if (!raycastHit.collider.TryGetComponent<IInteractable>(out var component)) return;
            component.LeftMouseInteract();
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (!MouseUtils.TryRaycast2DToMousePosition(out var raycastHit)) return;


            if (!raycastHit.collider.TryGetComponent<IInteractable>(out var component)) return;
            component.RightMouseInteract();
        }
    }
}
