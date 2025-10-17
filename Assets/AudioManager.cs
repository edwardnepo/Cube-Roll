using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource SFXSource;
    public AudioClip finishSound;  

    public void PlayFinishSound(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
