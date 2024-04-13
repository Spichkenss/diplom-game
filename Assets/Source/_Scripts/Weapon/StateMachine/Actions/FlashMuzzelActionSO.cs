using UnityEngine;

[CreateAssetMenu(fileName = "SO_FlashMuzzelAction",
    menuName = "Scriptable Objects/State Machine/Actions/Weapon/SO_FlashMuzzelAction")]
public class FlashMuzzelActionSO : StateActionSO
{
    protected override StateAction CreateAction() => new FlashMuzzelAction();
}

public class FlashMuzzelAction : StateAction
{
    protected new FlashMuzzelActionSO OriginSO => (FlashMuzzelActionSO)base.OriginSO;
    private Light _muzzleLight;
    private float _timer = 0f;
    private float _duration = 0.08f;
    private bool _isIncreasing = true;
    private float _minIntensity = 0f;
    private float _maxIntensity = 60f;

    public override void Awake(StateMachine stateMachine)
    {
        var weapon = stateMachine.GetComponent<Weapon>();
        _muzzleLight = weapon.Muzzle.GetComponentInChildren<Light>();
    }

    public override void OnUpdate()
    {
        if (_isIncreasing)
        {
            _timer += Time.deltaTime;
            if (_timer >= _duration)
            {
                _timer = _duration;
                _isIncreasing = false;
            }
        }
        else
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                _timer = 0;
                _isIncreasing = true;
            }
        }


        // Вычисляем текущую интенсивность с использованием линейной интерполяции
        float t = _timer / _duration;
        float currentIntensity = Mathf.Lerp(_minIntensity, _maxIntensity, t);

        // Устанавливаем текущую интенсивность света
        _muzzleLight.intensity = currentIntensity;
    }

    public override void OnStateEnter()
    {
    }

    public override void OnStateExit()
    {
        _muzzleLight.intensity = 0f;
    }
}
