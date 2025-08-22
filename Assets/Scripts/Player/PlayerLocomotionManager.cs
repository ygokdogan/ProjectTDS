using System;
using UnityEngine;

namespace Player
{
    public class PlayerLocomotionManager : MonoBehaviour
    {
        private PlayerManager player;
        
        public CharacterController CharController { get; private set; }
        
        public Vector3 moveDirection;

        public float moveSpeed = 5f;
        public float rotationSpeed = 15f;
        
        private void Start()
        {
            player = GetComponent<PlayerManager>();
            CharController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            HandleAllMovement();
            HandleRotation();
        }

        private void HandleAllMovement()
        {
            HandleLocomotion();
        }

        private void HandleLocomotion()
        {
            moveDirection = CameraManager.Forward * player.InputHandler.MoveInput.y + CameraManager.Right * player.InputHandler.MoveInput.x;
            moveDirection.y = 0f;
            moveDirection.Normalize();
            
            CharController.Move(moveDirection * (Time.deltaTime * moveSpeed));
        }
        
        private void HandleRotation()
        {
            if (moveDirection.magnitude < 0.1f || player.CombatManager.IsAiming) return;
            
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        
    }
}
