using Unity.Netcode;
using UnityEngine;

namespace Alpha
{
    public class PlayerUIManager : MonoBehaviour
    {
        public static PlayerUIManager instance;

        [Header("Network Join")]
        [SerializeField] private bool startGameAsClient;

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
        }

        private void Update()
        {
            if(startGameAsClient)
            {
                startGameAsClient = false;

                NetworkManager.Singleton.Shutdown();
                NetworkManager.Singleton.StartClient();
            }
        } 
    }
}
