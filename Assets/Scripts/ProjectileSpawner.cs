using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private Projectile _prefab;

    public void Spawn(Transform point)
    {
        Instantiate(_prefab, point.position, Quaternion.identity, point);
    }
}
