using TMPro;
using UnityEngine;

public class BulletsView : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    
    private TMP_Text _bulletsText;

    private void OnEnable()
    {
        _weapon.BulletCountChange += SetBulletsView;
    }

    private void OnDisable()
    {
        _weapon.BulletCountChange -= SetBulletsView;
    }

    private void Awake()
    {
        _bulletsText = GetComponent<TMP_Text>();
    }

    private void SetBulletsView(int current, int extra)
    {
        _bulletsText.text = $"{current} / {extra}";
    }
    
}
