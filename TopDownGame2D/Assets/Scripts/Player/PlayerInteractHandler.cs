using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInteractHandler : InteractHandler
    {
        public void Interact(InputAction.CallbackContext context)
        {
            if (context.started == false)
            {
                return;
            }
            Interact();
        }
    }
}
