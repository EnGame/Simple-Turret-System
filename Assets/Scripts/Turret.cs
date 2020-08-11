using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Profile")]
    [SerializeField] private TurretProfile profile;

    [Header("Objects")]
    [SerializeField] private Transform muzzle;
    [SerializeField] private GameObject head;

    [Header("Projectile")]
    [SerializeField] private GameObject projectile;

    private float fireTimer;
    private Enemy target;

    private void Start()
    {
        fireTimer = profile.fireRate;
    }

    private void Update()
    {
        if (fireTimer > 0)
            fireTimer -= Time.deltaTime;

        if (target == null)
        {
            target = GetNearestEnemy();
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) > profile.fireDistance)
                target = null;

            if (target == null) return;

            head.transform.LookAt(target.transform.position);

            if (fireTimer <= 0)
                Shoot();
        }
    }

    private Enemy GetNearestEnemy()
    {
        Enemy target = null;
        var minDistance = profile.fireDistance;
        foreach (var item in GameManager.instance.enemyList)
        {
            if (minDistance < Vector3.Distance(item.transform.position, transform.position)) continue;

            minDistance = Vector3.Distance(item.transform.position, transform.position);
            target = item;
        }
        return target;
    }

    private void Shoot()
    {
        fireTimer = profile.fireRate;
        target.ReceiveDamage(profile.attack);

        if (projectile == null) return;
        Instantiate(projectile, muzzle.position, muzzle.rotation);
    }

    private void OnDrawGizmosSelected()
    {
        if (profile == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, profile.fireDistance);
    }
}
