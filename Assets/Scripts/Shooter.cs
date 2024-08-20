using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField, Range(0, 3)] private float _force;

    private SpringJoint _joint;

    public void Init(SpringJoint joint)
    {
        _joint = joint;
    }

    public void Shoot()
    {
        StartCoroutine(ShootCoroutine());
    }

    private IEnumerator ShootCoroutine()
    {
        while(_joint.maxDistance > 0)
        {
            _joint.maxDistance -= _force;

            yield return null;
        }
    }
}
