using UnityEngine;
using UnityEngine.SceneManagement;

namespace Alpha
{
    public class PlayerInputManager : MonoBehaviour
    {
        public static PlayerInputManager instance;
        private PlayerControls playerControls;

        [SerializeField] private Vector2 movementInput;
        
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

        private void OnDestroy()
        {
            SceneManager.activeSceneChanged -= OnSceneChange;
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
    }
}
