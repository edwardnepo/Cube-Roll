using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera camera1; // המצלמה הראשונה
    public Camera camera2; // המצלמה השנייה
    
    private bool isFirstCameraActive = true;
    
    void Start()
    {
        // ודא שרק מצלמה אחת פעילה בהתחלה
        camera1.enabled = true;
        camera2.enabled = false;
    }
    
    void Update()
    {
        // בדיקה אם נלחץ כפתור (למשל רווח)
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera();
        }
    }
    
    void SwitchCamera()
    {
        if (isFirstCameraActive)
        {
            // עבור למצלמה שנייה
            camera1.enabled = false;
            camera2.enabled = true;
            isFirstCameraActive = false;
        }
        else
        {
            // חזור למצלמה ראשונה
            camera1.enabled = true;
            camera2.enabled = false;
            isFirstCameraActive = true;
        }
    }
}