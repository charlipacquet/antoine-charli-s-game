using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KartGame.KartSystems
{
    /// <summary>
    /// A basic keyboard implementation of the IInput interface for all the input information a kart needs.
    /// </summary>
    public class KeyboardInput : MonoBehaviour, IInput
    {
        public float Acceleration
        {
            get { return m_Acceleration; }
        }
        
        public Rigidbody projectile;

        public float Steering
        {
            get { return m_Steering; }
        }
        public bool BoostPressed
        {
            get { return m_BoostPressed; }
        }
        public bool FirePressed
        {
            get { return m_FirePressed; }
        }
        public bool HopPressed
        {
            get { return m_HopPressed; }
        }
        public bool HopHeld
        {
            get { return m_HopHeld; }
        }

        float m_Acceleration;
        float m_Steering;
        bool m_HopPressed;
        bool m_HopHeld;
        bool m_BoostPressed;
        bool m_FirePressed;

        bool m_FixedUpdateHappened;

        public KeyCode touchePourAvancer;
        public KeyCode touchepourReculer;
        public KeyCode touchepourDroite;
        public KeyCode touchepourGauche;
        public KeyCode touchepoursauter;
        public KeyCode touchepourCube;
        public KeyCode touchepourBoost;
        public KeyCode touchepourFire;

        void Update ()
        {
            if (Input.GetKey (touchePourAvancer))
                m_Acceleration = 1f;
            else if (Input.GetKey (touchepourReculer))
                m_Acceleration = -1f;
            else
                m_Acceleration = 0f;

            if (Input.GetKey (touchepourGauche) && !Input.GetKey (touchepourDroite))
                m_Steering = -1f;
            else if (!Input.GetKey (touchepourGauche) && Input.GetKey (touchepourDroite))
                m_Steering = 1f;
            else
                m_Steering = 0f;

            m_HopHeld = Input.GetKey (touchepoursauter);

            if (m_FixedUpdateHappened)
            {
                m_FixedUpdateHappened = false;

                m_HopPressed = false;
                m_BoostPressed = false;
                m_FirePressed = false;
            }

            m_HopPressed |= Input.GetKeyDown (touchepoursauter);
            m_BoostPressed |= Input.GetKeyDown (touchepourBoost);
            m_FirePressed |= Input.GetKeyDown (touchepourFire);
            if (Input.GetKeyUp(touchepourCube))
            {
                // Instantiate the projectile at the position and rotation of this transform
                Rigidbody clone;
                clone = Instantiate(projectile, transform.position - transform.forward, transform.rotation);
            }
        }

        void FixedUpdate ()
        {
            m_FixedUpdateHappened = true;
        }
    }
}