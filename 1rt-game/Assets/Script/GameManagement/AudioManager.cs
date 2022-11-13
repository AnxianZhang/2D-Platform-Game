using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    private AudioSource audioSource;
    private int numMusic = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.audioSource = gameObject.GetComponent<AudioSource>();
        this.audioSource.clip = playlist[numMusic];
        this.audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.audioSource.isPlaying)
            nextSong();
    }

    private void nextSong()
    {
        numMusic = (numMusic + 1) % this.playlist.Length;
        this.audioSource.clip = playlist[numMusic];
        this.audioSource.Play();
    }
}
