using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ManualPlayerController : MonoBehaviour
{
    public InputAction movement;

    public InputAction fire;

    public Transform bulletSpawnPoint;

    public GameObject bulletPrefab;

    public string enemyTank = "RightTank";

    public float bulletDirection = 1;

    public float bulletCooldownSeconds = 1f;

    private bool isCoolingDown;

    private void OnEnable()
    {
        movement.Enable();
        fire.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        fire.Disable();
    }

    void Update()
    {
        var delta = movement.ReadValue<Vector2>() * 400 * Time.deltaTime;
        transform.position += new Vector3(delta.x, delta.y, transform.position.z);

        if (fire.ReadValue<float>() > 0 && !isCoolingDown)
        {
            StartCoroutine(FireBullet());
        }
    }

    IEnumerator FireBullet()
    {
        isCoolingDown = true;

        var bullet = Instantiate(bulletPrefab,
                                 bulletSpawnPoint.transform.position,
                                 Quaternion.identity);
        var ctrl = bullet.GetComponent<SimpleBulletController>();
        ctrl.direction = bulletDirection;
        ctrl.enabled = true;

        var detection = bullet.GetComponent<BulletDetection>();
        detection.enemyTank = enemyTank;
        detection.BulletHit += Bullet_Hit;

        yield return new WaitForSeconds(bulletCooldownSeconds);
        isCoolingDown = false;
    }

    private void Bullet_Hit(object sender, EventArgs e)
    {
        (sender as BulletDetection).BulletHit -= Bullet_Hit;
        print("BANG!");
    }
}
