using UnityEngine;

public class ShootingEnemy : EnemyAI
{
    [Header("Targeting Shit")]
    [SerializeField]
    protected GameObject projectile;
    [SerializeField]
    protected Transform bulletSpawn;
    [SerializeField]
    protected float bulletSpeed;
    [SerializeField]
    protected float fireRate;
    protected float nextFire;
    [SerializeField]
    protected float errorMargin;
    [SerializeField]
    private float bulletTimer = 0f;
    [SerializeField]
    private AudioClip[] gunShots = null;

    protected override void Tartgeting()
    {
        if (player != null)
        {
            Vector3 direction = player.transform.position - this.transform.position;
            direction.y = 0f;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

            playerDist = this.transform.position - player.transform.position;
            playerDist.y = 0f;

            if (playerDist.magnitude < range)
            {
                if (Time.time > nextFire)
                {
                    audioSource.PlayOneShot(gunShots[Random.Range(0, gunShots.Length)]);
                    Vector3 shootDirection = player.transform.position + Random.insideUnitSphere * errorMargin - bulletSpawn.position;
                    nextFire = Time.time + fireRate;
                    GameObject bullet = Instantiate(projectile, bulletSpawn.position, bulletSpawn.rotation);
                    bullet.GetComponent<Rigidbody>().AddForce(shootDirection * bulletSpeed);
                    Destroy(bullet.gameObject, bulletTimer);
                }
            }
        }
    }

    protected override void ChangeState(int id)
    {
        if (id == this.id)
        {
            audioSource.outputAudioMixerGroup = sfxVolume;
            audioSource.spatialBlend = 1.0f;
            state = EnemyState.shooting;
        }
    }
}
