using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class CameraActivator : MonoBehaviour
{
    public Camera cameraToActivate;   // The Camera to activate/deactivate. Drag this in the Inspector.
    public Button activationButton; // The Button that toggles the camera. Drag this in the Inspector.

    private void Start()
    {
        // Ensure the camera starts disabled. Check for null reference before accessing it.
        if (cameraToActivate != null)
        {
            cameraToActivate.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Camera to activate is not assigned in the Inspector!");
            return; // Prevent further errors if the camera is not assigned.
        }

        // Add a listener to the button's onClick event. Check for null reference before adding the listener.
        if (activationButton != null)
        {
            activationButton.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogError("Button is not assigned in the Inspector!");
        }
    }

    private void OnButtonClick()
    {
        // Toggle the camera's active state. Check for null reference before toggling.
        if (cameraToActivate != null)
        {
            cameraToActivate.gameObject.SetActive(!cameraToActivate.gameObject.activeSelf);

            // Provide feedback to the console about the camera's state.
            Debug.Log($"Camera {(cameraToActivate.gameObject.activeSelf ? "Activated" : "Deactivated")}!"); // Improved logging
        }
    }
}