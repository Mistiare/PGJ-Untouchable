using UnityEngine;
using UnityEngine.SceneManagement;

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
            KillPlayer(collision.gameObject);
        }
        Destroy(this.gameObject);
    }

    private void Update()
    {
        Destroy(this.GetComponent<TrailRenderer>(), trailTimer);
    }

    private void KillPlayer(GameObject player)
    {
        Destroy(player);
    }
}
