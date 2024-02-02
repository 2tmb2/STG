using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSound : MonoBehaviour
{
    public AudioClip[] AudioClips;
    private int whichClip;
    private AudioSource source;
    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    void Start()
    {
        StartCoroutine(nameof(RandomAudios));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RandomAudios()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            source.PlayOneShot(AudioClips[Random.Range(0, AudioClips.Length)]);
            yield return null;
        }
    }
}
