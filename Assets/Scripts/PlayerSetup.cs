using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;


namespace UnityStandardAssets.Characters.FirstPerson
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(AudioSource))]
    public class PlayerSetup : MonoBehaviour
    {
        public FirstPersonController movement;
        public GameObject camera;

        public void IsLocalPLayer()
        {
            movement.enabled = true;
            camera.SetActive(true);
        }
    }
}