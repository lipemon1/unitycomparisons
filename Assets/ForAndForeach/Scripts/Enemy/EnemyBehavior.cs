using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ForAndForeach
{
    public class EnemyBehavior : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _minPos;

        [SerializeField]
        private Vector3 _maxPos;

        [SerializeField]
        private float _timeToTakeDamage;

        [SerializeField]
        private int _minDamage;

        [SerializeField]
        private int _maxDamage;

        [SerializeField]
        private Material AliveColor;

        [SerializeField]
        private Material DeadColor;

        [SerializeField]
        private MeshRenderer _meshRenderer;

        private Enemy _enemy;

        public void StartEnemy(Enemy enemy)
        {
            _enemy = enemy;

            SetPosition();
            InvokeRepeating(nameof(TryToDie), 0f, _timeToTakeDamage);
        }

        private void SetPosition()
        {
            float posX = Random.Range(_minPos.x, _maxPos.x);
            float posY = Random.Range(_minPos.y, _maxPos.y);
            float posZ = Random.Range(_minPos.z, _maxPos.z);

            transform.position = new Vector3(posX, posY, posZ);
        }

        private void TryToDie()
        {
            ChangeColor(_enemy.TakeDamage(Random.Range(_minDamage, _maxDamage)));
        }

        private void ChangeColor(bool isDead)
        {
            if (isDead)
                _meshRenderer.material = DeadColor;
            else
                _meshRenderer.material = AliveColor;
        }

        public bool IsDead()
        {
            return _enemy.IsDead();
        }
    }
}