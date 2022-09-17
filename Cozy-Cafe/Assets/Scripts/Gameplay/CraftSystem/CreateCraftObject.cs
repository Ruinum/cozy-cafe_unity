using UnityEngine;


public class CreateCraftObject : MonoBehaviour, IInteractable
{
    public void LeftMouseInteract()
    {
        CraftSystem.Singleton.TryCreateCraftObject();
    }

    public void RightMouseInteract()
    {
    }
}
