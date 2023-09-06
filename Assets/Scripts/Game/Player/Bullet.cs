using System;
using UnityEngine;

namespace Default
{
    public class Bullet : MonoBehaviour
    {
        public int Damage { get; private set; }
        private Vector3 _direction;

        private void Start()
        {
            Damage = 1;
        }

        public void Setup(Vector2 direction)
        {
            _direction = direction;
            float timeToDestroy = 5f;//0.5f
            Destroy(gameObject, timeToDestroy);
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
            }
            else
            {
                Destroy(gameObject);
            }
        }
        private void Update()
        {
            float speed = 3f;//15f
            transform.position += _direction * Time.deltaTime * speed;
        }
    }
}
