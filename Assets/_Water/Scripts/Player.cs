using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace com.IsartDigital.Water._Water.Scripts
{
    public class Player : MonoBehaviour
    {
        private InputSystem_Actions inputSystem;

        [Header("Side movement")]
        [SerializeField] 
        private Vector2 MinMaxPos;
        [SerializeField] 
        private float SideSpeed = 100;

        [Header("Jump")]
        private bool IsPreparingJump = false;
        private float JumpForce = 0;
        [SerializeField] 
        private float maxJumpForce = 3;
        
        private void Start()
        {
            inputSystem = new();
            inputSystem.Player.Jump.started += PrepareJump;
            inputSystem.Enable();

            Initialisation();
        }

        private void Update()
        {
            Move(inputSystem.Player.Move.ReadValue<Vector2>().x);
        }

        private void Initialisation()
        {
            SetXPosition((MinMaxPos.y - MinMaxPos.x) / 2 + MinMaxPos.x);
        }

        private void Move(float dir)
        {
            float newPos = Mathf.Clamp(transform.position.x + (dir * SideSpeed * Time.deltaTime), MinMaxPos.x,
                MinMaxPos.y);
            SetXPosition(newPos);
        }

        private void PrepareJump(InputAction.CallbackContext context)
        {
            IsPreparingJump = true;
            JumpForce = 0;
        }

        private void StartJump(InputAction.CallbackContext context)
        {

        }

        private  void SetXPosition(float newXValue) =>
            transform.position = new Vector3(newXValue, transform.position.y, transform.position.z);
    }
}
