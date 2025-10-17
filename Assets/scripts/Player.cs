using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour
{
    public AudioSource finishSound;
    public Animator animator;
    
    public enum MoveType { ForwardBack, LeftRight }
    public MoveType moveType = MoveType.ForwardBack;
    public float speed = 5f;

    private Rigidbody rb;
    private bool hasFinished = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // קבל את האנימטור אוטומטית
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void FixedUpdate()
    {
        if (!hasFinished)
        {
            float move = 0f;

            if (moveType == MoveType.ForwardBack)
            {
                move = Input.GetAxis("Vertical");
                rb.linearVelocity = new Vector3(0, 0, move * speed);
            }
            else if (moveType == MoveType.LeftRight)
            {
                move = Input.GetAxis("Horizontal");
                rb.linearVelocity = new Vector3(move * speed, 0, 0);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.CompareTag("Player") && other.gameObject.CompareTag("Finish") && !hasFinished)
        {
            hasFinished = true;
            StartCoroutine(FinishLevel());
        }
    }
    
    IEnumerator FinishLevel()
    {
        // עצור את התנועה
        rb.linearVelocity = Vector3.zero;
        
        // נגן את הסאונד
        finishSound.Play();
        
        // עכשיו הפעל את האנימציה
        if (animator != null)
        {
            animator.SetTrigger("Win");
        }
        
        // חכה עוד קצת (סאונד + אנימציה)
        yield return new WaitForSeconds(1.4f);
        
        // עבור לשלב הבא
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}