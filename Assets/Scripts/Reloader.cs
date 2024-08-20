using System;
using System.Collections;
using UnityEngine;

public class Reloader : MonoBehaviour
{
    [SerializeField] private ProjectileSpawner _spawner;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _distance;

    private SpringJoint _joint;

    public event Action Reloaded;

    public void Init(SpringJoint joint)
    {
        _joint = joint;

        _spawner.Spawn(_shootPoint);
    }

    public void Reload()
    {
        _joint.maxDistance = _distance;

        StartCoroutine(ReloadCoroutine());
    }

    private IEnumerator ReloadCoroutine()
    {
        float epsilon = 0.01f;
        float distance = _distance - epsilon;

        while(Vector3.Distance(_joint.transform.TransformPoint(_joint.anchor), _joint.connectedBody.transform.TransformPoint(_joint.connectedAnchor)) < distance)
            yield return null;

        _spawner.Spawn(_shootPoint);
        Reloaded?.Invoke();
    }
}
