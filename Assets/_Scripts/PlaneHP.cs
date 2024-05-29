using UnityEngine;
using UnityEngine.UI;

public class PlaneHP : MonoBehaviour
{
    [SerializeField] private Image _hpBar;
    [SerializeField] private float _maximumHP;
    [SerializeField] private GameObject _parts;
    public static float CurrentHp;

    private void Start()
    {
        CurrentHp = _maximumHP;
    }

    private void Update()
    {
        _hpBar.fillAmount = CurrentHp / _maximumHP;

        if (CurrentHp <= 0)
        {
            GameObject parts = Instantiate(_parts);
            parts.transform.position = gameObject.transform.position;
            Destroy(gameObject);
            PlanesCounter.DestroyedPlanes++;
            if (PlanesCounter.DestroyedPlanes == GameManager.CurrentLevel)
            {
                PlaneSpawner.CanSpawnPlane = false;
            }
            else PlaneSpawner.CanSpawnPlane = true;
        }
    }
}
