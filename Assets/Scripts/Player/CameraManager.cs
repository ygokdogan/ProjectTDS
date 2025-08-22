using System;
using UnityEngine;

namespace Player
{
    public class CameraManager : MonoBehaviour
    {
        public static Vector3 Forward;
        public static Vector3 Right;

        private void Update()
        {
            GetCameraDirections();
        }

        private void GetCameraDirections()
        {
            Forward = transform.forward;
            Right = transform.right;

            Forward.y = 0f;
            Right.y = 0f;
            
            Forward.Normalize();
            Right.Normalize();
        }
    }
}
