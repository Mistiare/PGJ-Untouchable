using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    [SerializeField]
    private float trailTimer = 0f;
    [SerializeField]
    private float playerForce = 0f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Hit PLayer");
            collision.gameObject.GetComponent<Rigidbody>().AddForce(this.transform.forward * playerForce);
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        Destroy(this.GetComponent<TrailRenderer>(), trailTimer);

    }


}
