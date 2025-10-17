using UnityEngine;
using UnityEngine.SceneManagement;

public class Plane_controll : MonoBehaviour
{
    public float tiltSpeed = 50f;   // מהירות סיבוב
    public float maxTilt = 20f;     // זווית מקסימלית

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // לוודא שהפלטפורמה היא Kinematic כדי שלא תיפול בעצמה
        if (rb != null)
        {
            rb.isKinematic = true;
        }
        else
        {
            Debug.LogWarning("No Rigidbody found on Plane. Please add one.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void FixedUpdate()
    {
        float tiltX = Input.GetAxis("Vertical") * tiltSpeed * Time.fixedDeltaTime;
        float tiltZ = -Input.GetAxis("Horizontal") * tiltSpeed * Time.fixedDeltaTime;

        // לקרוא את הסיבוב הנוכחי
        Vector3 currentRotation = rb.rotation.eulerAngles;

        // לחשב את הזוויות עם Clamp
        float newX = Mathf.Clamp(NormalizeAngle(currentRotation.x + tiltX), -maxTilt, maxTilt);
        float newZ = Mathf.Clamp(NormalizeAngle(currentRotation.z + tiltZ), -maxTilt, maxTilt);

        // להזיז עם MoveRotation (כדי שהפיזיקה תעדכן את הכדור)
        Quaternion targetRotation = Quaternion.Euler(newX, 0, newZ);
        rb.MoveRotation(targetRotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    float NormalizeAngle(float angle)
    {
        if (angle > 180) angle -= 360;
        return angle;
    }
}