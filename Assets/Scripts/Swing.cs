using UnityEngine;

[RequireComponent (typeof(HingeJoint))]
public class Swing : MonoBehaviour
{
    [SerializeField] private float _force;

    private HingeJoint _joint;
    private JointMotor _defaultMotor;
    private JointMotor _swingMotor;

    private void Awake()
    {
        _joint = GetComponent<HingeJoint>();

        _defaultMotor = _joint.motor;
        _swingMotor = _defaultMotor;

        _swingMotor.force = _force;
    }

    public void AddForce()
    {
        if (_joint.motor.Equals(_swingMotor))
            return;

        _joint.motor = _swingMotor;
    }

    public void RemoveForce()
    {
        _joint.motor = _defaultMotor;
    }
}
