using UnityEngine;

namespace Alpha
{
    public class PlayerInputManager : MonoBehaviour
    {
        private PlayerControls playerControls;

        [SerializeField] private Vector2 movementInput;

        private void OnEnable()
        {
            if(playerControls == null)
            {
                playerControls = new PlayerControls();

                playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            }

            playerControls.Enable();
        }
    }
}
