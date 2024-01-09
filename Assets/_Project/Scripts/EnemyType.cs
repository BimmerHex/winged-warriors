using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VGS
{
    [CreateAssetMenu(fileName = "EnemyType", menuName = "VGS/EnemyType", order = 0)]
    public class EnemyType : ScriptableObject
    {
        public GameObject enemyPrefab;
        public GameObject weaponPrefab;
        public float speed = 2f;
    }
}
