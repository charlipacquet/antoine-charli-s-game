using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboarkarttwo : MonoBehaviour
{
    public float Acceleration1
        {
            get { return m_Acceleration; }
        }
        
        public Rigidbody projectile;

        public float Steering1
        {
            get { return m_Steering; }
        }
        public bool BoostPressed1
        {
            get { return m_BoostPressed; }
        }
        public bool FirePressed1
        {
            get { return m_FirePressed; }
        }
        public bool HopPressed1
        {
            get { return m_HopPressed; }
        }
        public bool HopHeld1
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

        void Update ()
        {
            if (Input.GetKey (KeyCode.Z))
                m_Acceleration = 1f;
            else if (Input.GetKey (KeyCode.S))
                m_Acceleration = -1f;
            else
                m_Acceleration = 0f;

            if (Input.GetKey (KeyCode.Q) && !Input.GetKey (KeyCode.D))
                m_Steering = -1f;
            else if (!Input.GetKey (KeyCode.Q) && Input.GetKey (KeyCode.D))
                m_Steering = 1f;
            else
                m_Steering = 0f;

            m_HopHeld = Input.GetKey (KeyCode.W);

            if (m_FixedUpdateHappened)
            {
                m_FixedUpdateHappened = false;

                m_HopPressed = false;
                m_BoostPressed = false;
                m_FirePressed = false;
            }

            m_HopPressed |= Input.GetKeyDown (KeyCode.W);
            m_BoostPressed |= Input.GetKeyDown (KeyCode.LeftShift);
            m_FirePressed |= Input.GetKeyDown (KeyCode.LeftControl);
            if (Input.GetKeyUp(KeyCode.T))
            {
                // Instantiate the projectile at the position and rotation of this transform
                Rigidbody clone;
                clone = Instantiate(projectile, transform.position-transform.forward, transform.rotation);
                
            }
        }

        void FixedUpdate ()
        {
            m_FixedUpdateHappened = true;
        }
}
