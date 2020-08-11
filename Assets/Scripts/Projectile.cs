using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 80, Space.Self);
        Destroy(gameObject, 0.3f);
    }
}
