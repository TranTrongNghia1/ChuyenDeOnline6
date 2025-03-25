using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // Use UI elements
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Image))]  // Ensure an Image component is attached
public class ForcedReset : MonoBehaviour
{
    private void Update()
    {
        // If the "ResetObject" button is pressed...
        if (CrossPlatformInputManager.GetButtonDown("ResetObject"))
        {
            // ,reload the active scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
