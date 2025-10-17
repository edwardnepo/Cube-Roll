using UnityEngine;

public class SimpleButton : MonoBehaviour
{
    [Header("Block to Control")]
    public GameObject blockToToggle;
    
    [Header("Materials")]
    public Material normal;
    public Material transparent;
    
    [Header("Settings")]
    public bool resetOnExit = false; // האם לחזור למצב רגיל כשיוצאים מהכפתור

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube") || other.CompareTag("Player"))
        {
            // הפוך את הבלוק לשקוף וניתן למעבר
            if (blockToToggle != null)
            {
                Renderer blockRenderer = blockToToggle.GetComponent<Renderer>();
                Collider blockCollider = blockToToggle.GetComponent<Collider>();
                
                if (blockRenderer != null) 
                    blockRenderer.material = transparent;
                
                if (blockCollider != null) 
                    blockCollider.isTrigger = true;
            }
            
            Debug.Log("Button pressed! Block is now transparent.");
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (resetOnExit && (other.CompareTag("Cube") || other.CompareTag("Player")))
        {
            // החזר את הבלוק למצב רגיל
            if (blockToToggle != null)
            {
                Renderer blockRenderer = blockToToggle.GetComponent<Renderer>();
                Collider blockCollider = blockToToggle.GetComponent<Collider>();
                
                if (blockRenderer != null) 
                    blockRenderer.material = normal;
                
                if (blockCollider != null) 
                    blockCollider.isTrigger = false;
            }
            
            Debug.Log("Button released! Block is back to normal.");
        }
    }
}