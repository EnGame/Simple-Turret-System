using UnityEngine;

[CreateAssetMenu(fileName = "New Turret Profile", menuName = "Turret Profile", order = 0)]
public class TurretProfile : ScriptableObject
{
    [Header("Fire Settings")]
    public float fireRate;
    public float fireDistance;
    public int attack;
}
