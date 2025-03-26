using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class AxisTouchButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public string axisName = "Horizontal"; // The name of the axis
        public float axisValue = 1; // The axis value to be applied
        public float responseSpeed = 3; // Speed at which the axis reacts
        public float returnToCentreSpeed = 3; // Speed at which it returns to the center

        private AxisTouchButton m_PairedWith; // The paired button for the opposite direction
        private CrossPlatformInputManager.VirtualAxis m_Axis; // Reference to the virtual axis

        void OnEnable()
        {
            if (!CrossPlatformInputManager.AxisExists(axisName))
            {
                // If the axis doesn't exist, create it
                m_Axis = new CrossPlatformInputManager.VirtualAxis(axisName);
                CrossPlatformInputManager.RegisterVirtualAxis(m_Axis);
            }
            else
            {
                m_Axis = CrossPlatformInputManager.VirtualAxisReference(axisName);
            }

            FindPairedButton();
        }

        void FindPairedButton()
        {
            // Find all buttons that use the same axis
            var otherAxisButtons = FindObjectsByType<AxisTouchButton>(FindObjectsSortMode.None);

            foreach (var button in otherAxisButtons)
            {
                if (button.axisName == axisName && button != this)
                {
                    m_PairedWith = button;
                    break;
                }
            }
        }

        void OnDisable()
        {
            // Remove from cross-platform input when disabled
            m_Axis.Remove();
        }

        public void OnPointerDown(PointerEventData data)
        {
            if (m_PairedWith == null)
            {
                FindPairedButton();
            }
            m_Axis.Update(Mathf.MoveTowards(m_Axis.GetValue, axisValue, responseSpeed * Time.deltaTime));
        }

        public void OnPointerUp(PointerEventData data)
        {
            m_Axis.Update(Mathf.MoveTowards(m_Axis.GetValue, 0, responseSpeed * Time.deltaTime));
        }
    }
}
