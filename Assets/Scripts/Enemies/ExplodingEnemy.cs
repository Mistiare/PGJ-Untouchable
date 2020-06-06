using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplodingEnemy : EnemyAI
{
    [SerializeField]
    private float explosiveForce = 0f;
    [SerializeField]
    private float explosiveRadius = 0f;
    [SerializeField]
    private GameObject explosion = null;

    protected override void Exploding()
    {
        Vector3 direction = player.transform.position - this.transform.position;
        direction.y = 0f;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

        playerDist = this.transform.position - player.transform.position;
        playerDist.y = 0f;

        if (direction.magnitude > .8)
        {
            moveDir = direction.normalized;
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        if (playerDist.magnitude < range)
        {
            GameObject explosive = Instantiate(explosion, this.transform.position, this.transform.rotation);
            player.GetComponent<Rigidbody>().AddExplosionForce(explosiveForce, this.transform.position, explosiveRadius);
            Destroy(this.gameObject);
            Destroy(player);
        }
    }
    protected override void ChangeState(int id)
    {
        if (id == this.id)
        {
            state = EnemyState.exploding;
        }
    }
}
