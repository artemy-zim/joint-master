using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private Swing _swing;
    [SerializeField] private Catapult _catapult;

    private PlayerInput _input;

    private void Awake()
    {
        _input = new PlayerInput();

        _input.Player.Swing.performed += (ctx) => _swing.AddForce();
        _input.Player.Swing.canceled += (ctx) => _swing.RemoveForce();

        _input.Player.CatapultReload.performed += (ctx) => _catapult.Reload();
        _input.Player.CatapultShoot.performed += (ctx) => _catapult.Shoot();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }
}
