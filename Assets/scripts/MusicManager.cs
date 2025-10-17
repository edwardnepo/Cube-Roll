using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    
    void Awake()
    {
        // בדיקה אם כבר יש MusicManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // זה הקסם!
        }
        else
        {
            Destroy(gameObject); // מוחק עותקים כפולים
        }
    }
}