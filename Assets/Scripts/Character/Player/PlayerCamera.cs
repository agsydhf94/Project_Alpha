using UnityEngine;

namespace Alpha
{
    public class PlayerCamera : MonoBehaviour
    {
        public static PlayerCamera instance;

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
    }
}
