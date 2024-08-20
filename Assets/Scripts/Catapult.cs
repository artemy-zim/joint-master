using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Catapult : MonoBehaviour
{
    [SerializeField] private SpringJoint _joint;
    [SerializeField] private Shooter _shooter;
    [SerializeField] private Reloader _reloader;

    private Rigidbody _rigidbody;
    private bool _canShoot = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _shooter.Init(_joint);
        _reloader.Init(_joint);
    }

    private void OnEnable()
    {
        _reloader.Reloaded += OnReloaded;
    }

    private void OnDisable()
    {
        _reloader.Reloaded -= OnReloaded;
    }

    public void Shoot()
    {
        if(_canShoot)
        {
            _shooter.Shoot();
            _canShoot = false;
        }
    }

    public void Reload()
    {
        if(_canShoot)
            return;

        _reloader.Reload();
    }

    private void OnReloaded()
    {
        _rigidbody.Sleep();
        _canShoot = true;
    }
}
