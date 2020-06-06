using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seashanty : MonoBehaviour{

    public int SeaShantyProb;
    [SerializeField]
    public AudioSource audioSource;
    [SerializeField]
    public AudioClip seaShanty;

    public void Start()
    {
        RandomNumber();
    }


    public void RandomNumber()
    {
        SeaShantyProb = Random.Range(1, 2000);

        if (SeaShantyProb == 13)
        {
            audioSource.PlayOneShot(seaShanty);
        }
    }



}
