using UnityEngine;
using UnityEngine.Splines;
using VGS.Utilities;

namespace VGS
{
    public class EnemyBuilder
    {
        private GameObject enemyPrefab;
        private SplineContainer spline;
        private GameObject weaponPrefab;
        private float speed;

        public EnemyBuilder SetBasePrefab(GameObject prefab) {
            enemyPrefab = prefab;
            return this;
        }

        public EnemyBuilder SetSpline(SplineContainer spline) {
            this.spline = spline;
            return this;
        }

        public EnemyBuilder SetWeaponPrefab(GameObject prefab) {
            weaponPrefab = prefab;
            return this;
        }

        public EnemyBuilder SetSpeed(float speed)
        {
            this.speed = speed;
            return this;
        }

        public GameObject Build()
        {
            GameObject instance = GameObject.Instantiate(enemyPrefab);

            SplineAnimate splineAnimate = instance.GetOrAdd<SplineAnimate>();
            splineAnimate.Container = spline;
            splineAnimate.AnimationMethod = SplineAnimate.Method.Speed;
            splineAnimate.ObjectUpAxis = SplineComponent.AlignAxis.ZAxis;
            splineAnimate.ObjectForwardAxis = SplineComponent.AlignAxis.YAxis;
            splineAnimate.MaxSpeed = speed;

            // Weapons in Part 3

            // Set instance transform to spline start position
            instance.transform.position = spline.EvaluatePosition(0);
            // NOTE: If instantiating waves, coult set the position along the spline in a staggered value 0f to 1f.

            return instance;
        }
    }
}
