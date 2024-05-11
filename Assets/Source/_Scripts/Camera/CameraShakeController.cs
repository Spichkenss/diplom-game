using System.Collections;
using Cinemachine;
using UnityEngine;

public class CameraShakeController : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float shakeIntensity = 5f;
    [SerializeField] private float shakeTiming = 0.5f;

    private CinemachineVirtualCamera _vcam;

    private void Awake()
    {
        _vcam = GetComponent<CinemachineVirtualCamera>();
    }

    private void OnEnable()
    {
        _weapon.ShotFired += OnShotFired;
    }

    private void OnDisable()
    {
        _weapon.ShotFired -= OnShotFired;
    }

    private void OnShotFired()
    {
        StartCoroutine(ProcessShake());
    }

    private IEnumerator ProcessShake()
    {
        Noise(1, shakeIntensity);
        yield return new WaitForSeconds(shakeTiming);
        Noise(0, 0);
    }

    public void Noise(float amplitudeGain, float frequencyGain)
    {
        var perlin = _vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        perlin.m_AmplitudeGain = amplitudeGain;
        perlin.m_FrequencyGain = frequencyGain;
    }
}
