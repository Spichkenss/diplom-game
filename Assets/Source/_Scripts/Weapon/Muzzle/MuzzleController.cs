using UnityEngine;

public class MuzzleController : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Light _light;

    private void Awake()
    {
        _light.intensity = 0f;
    }

    private void OnEnable()
    {
        _weapon.ShotFired += FlashMuzzle;
    }

    private void OnDisable()
    {
        _weapon.ShotFired -= FlashMuzzle;
    }

    private void Update()
    {
        _light.intensity = Mathf.Lerp(_light.intensity, 0, 20f * Time.deltaTime);
    }

    private void FlashMuzzle()
    {
        _light.intensity = 800f;
    }
}
