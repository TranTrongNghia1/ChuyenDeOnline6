using UnityEngine;
using UnityEngine.UI;

public class SimpleActivatorMenu : MonoBehaviour
{
    // UI Button to display current object
    public Text camSwitchButton;
    public GameObject[] objects;

    private int m_CurrentActiveObject;

    private void OnEnable()
    {
        if (objects == null || objects.Length == 0)
        {
            Debug.LogWarning("No objects assigned to SimpleActivatorMenu.");
            return;
        }

        // Ensure only the first object is active
        m_CurrentActiveObject = 0;
        UpdateActiveObject();
    }

    public void NextCamera()
    {
        if (objects == null || objects.Length == 0) return;

        // Cycle to the next object
        m_CurrentActiveObject = (m_CurrentActiveObject + 1) % objects.Length;
        UpdateActiveObject();
    }

    private void UpdateActiveObject()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(i == m_CurrentActiveObject);
        }

        if (camSwitchButton != null)
        {
            camSwitchButton.text = objects[m_CurrentActiveObject].name;
        }
    }
}
