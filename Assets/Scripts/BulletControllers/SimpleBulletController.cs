using System.Collections;
using UnityEngine;

public class SimpleBulletController : MonoBehaviour
{
    float ttl = 2f;

    public float direction = 1;

    public float unitsPerSec = 600;

    IEnumerator Start()
    {
        while (ttl > 0)
        {
            ttl -= Time.deltaTime;
            transform.position += Vector3.right * direction * unitsPerSec * Time.deltaTime;

            yield return null;
        }

        Destroy(gameObject);
    }
}
