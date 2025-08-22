using System;
using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        public InputHandler InputHandler { get; private set; }
        public Animator Anim { get; private set; }
        public PlayerLocomotionManager LocomotionManager { get; private set; }
        public PlayerCombatManager CombatManager { get; private set; }

        private void Start()
        {
            InputHandler = GetComponent<InputHandler>();
            Anim = GetComponent<Animator>();
            LocomotionManager = GetComponent<PlayerLocomotionManager>();
            CombatManager = GetComponent<PlayerCombatManager>();
        }

        private void Update()
        {
            SetAnimVariables();
        }

        private void SetAnimVariables()
        {
            var xVelocity = Vector3.Dot(LocomotionManager.moveDirection, transform.right);
            var zVelocity = Vector3.Dot(LocomotionManager.moveDirection, transform.forward);
            
            Anim.SetFloat("velocity", LocomotionManager.CharController.velocity.magnitude, 0.02f, Time.deltaTime);
            Anim.SetFloat("velocityX", xVelocity, 0.05f, Time.deltaTime);
            Anim.SetFloat("velocityY", zVelocity, 0.05f , Time.deltaTime);

            Anim.SetBool("isArmed", CombatManager.IsAiming);
        }
    }
}
