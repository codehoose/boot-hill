using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ManualPlayerController : MonoBehaviour
{
    public InputAction movement;

    public InputAction fire;

    public Transform bulletSpawnPoint;

    public GameObject bulletPrefab;

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

        yield return new WaitForSeconds(bulletCooldownSeconds);
        isCoolingDown = false;
    }
}
