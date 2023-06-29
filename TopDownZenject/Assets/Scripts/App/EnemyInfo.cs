using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownZenject

{

    [CreateAssetMenu(menuName = "Tools/Enemy Info", fileName = "EnemyInfo")]
    public class EnemyInfo : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public GameObject Prefab { get; private set; }
        [field: SerializeField] public int Speed { get; private set; }
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public int Vision { get; private set; }
        [field: SerializeField] public GameObject Particle { get; private set; }

    }
}
