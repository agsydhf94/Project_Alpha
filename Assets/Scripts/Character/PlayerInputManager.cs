using UnityEngine;
using UnityEngine.SceneManagement;

namespace Alpha
{
    public class PlayerInputManager : MonoBehaviour
    {
        public static PlayerInputManager instance;
        private PlayerControls playerControls;

        [SerializeField] private Vector2 movementInput;
        public float horizontalInput;
        public float verticalInput;
        public float moveAmount;
        
        private void OnEnable()
        {
            if (playerControls == null)
            {
                playerControls = new PlayerControls();

                playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            }

            playerControls.Enable();
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            SceneManager.activeSceneChanged += OnSceneChange;
        }

        private void Update()
        {
            HandleMovementInput();
        }

        private void OnDestroy()
        {
            SceneManager.activeSceneChanged -= OnSceneChange;
        }

        private void OplicationFocus(bool focus)
        {
            if(enabled)
            {
                if (focus)
                {
                    playerControls.Enable();
                }
                else
                {
                    playerControls.Disable();
                }
            }
        }

        private void OnSceneChange(Scene oldScene, Scene newScene)
        {
            if (newScene.buildIndex == WorldSaveGameManager.instance.GetWorldSceneIndex())
            {
                instance.enabled = true;
            }
            else
            {
                instance.enabled = false;
            }
        }

        private void HandleMovementInput()
        {
            verticalInput = movementInput.y;
            horizontalInput = movementInput.x;

            moveAmount = Mathf.Clamp01(Mathf.Abs(verticalInput) + Mathf.Abs(horizontalInput));

            if (moveAmount <= 0.5f && moveAmount > 0)
            {
                moveAmount = 0.5f;
            }
            else if(moveAmount > 0.5f && moveAmount <= 1f)
            {
                moveAmount = 1f;
            }
        }
    }
}
