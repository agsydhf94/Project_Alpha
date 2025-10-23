using UnityEngine;

namespace Alpha
{
    public class CharacterManager : MonoBehaviour
    {
        public CharacterController characterController;

        protected virtual void Awake()
        {
            DontDestroyOnLoad(this);

            characterController = GetComponent<CharacterController>();
        }

        protected virtual void Update()
        {
            
        }
    }
}
