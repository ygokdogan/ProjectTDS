using System;
using UnityEngine;

namespace Player
{
    public class PlayerCombatManager : MonoBehaviour
    {
        public LayerMask aimableLayers;
        private PlayerManager player;
        
        private Vector3 lookDirection;
        public Transform aimPosition;

        public bool IsAiming { get; private set; }

        private void Start()
        {
            player = GetComponent<PlayerManager>();
            IsAiming = true;
        }

        private void Update()
        {
            if(IsAiming)
                GetAimDirection();

            if (player.InputHandler.TestInput)
            {
                IsAiming = !IsAiming;
                player.InputHandler.UseTestInput();
            }
        }

        private void GetAimDirection()
        {
            Ray ray = Camera.main.ScreenPointToRay(player.InputHandler.AimInput);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, aimableLayers))
            {
                lookDirection = hitInfo.point - transform.position;
                lookDirection.y = 0;
                lookDirection.Normalize();
                
                transform.forward = lookDirection;
                aimPosition.position = new Vector3(hitInfo.point.x, transform.position.y + 1.3f, hitInfo.point.z);
            }
        }
    }
}
