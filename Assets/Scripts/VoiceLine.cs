using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceLine : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] voiceLines = null;
    private AudioSource audioSource = null;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.OnVoiceTriggerEnter += PlayVoiceLine;
        this.GetComponent<AudioSource>();
    }

    private void PlayVoiceLine(int id)
    {
        audioSource.PlayOneShot(voiceLines[Random.Range(0, voiceLines.Length)]);
    }
}
