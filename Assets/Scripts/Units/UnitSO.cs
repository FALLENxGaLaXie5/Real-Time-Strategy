using UnityEngine;

namespace Units
{
    [CreateAssetMenu(fileName = "Unit", menuName = "Units/Unit", order = 0)]
    public class UnitSO : ScriptableObject
    {
        [field: SerializeField] public int Health { get; private set; } = 100;

    }
}