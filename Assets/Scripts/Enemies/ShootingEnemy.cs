using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : EnemyAI
{
    [SerializeField]
    private float bulletTimer = 0f;
    [SerializeField]
    private float range = 0f;
    protected override void Tartgeting()
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
                Vector3 shootDirection = player.transform.position + Random.insideUnitSphere * errorMargin - bulletSpawn.position;
                nextFire = Time.time + fireRate;
                GameObject bullet = Instantiate(projectile, bulletSpawn.position, bulletSpawn.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(shootDirection * bulletSpeed);
                Destroy(bullet.gameObject, bulletTimer);
            }
        }
    }
}
