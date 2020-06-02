using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    [SerializeField]
    private float trailTimer;
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

    private void Update()
    {
        Destroy(this.GetComponent<TrailRenderer>(), trailTimer);

    }


}
