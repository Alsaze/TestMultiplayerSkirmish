using System;
using UnityEngine;

namespace Default
{
    public class Bullet : MonoBehaviour
    {
        private Vector3 _direction;

        public void Setup(Vector2 direction)
        {
            _direction = direction;
            float timeToDestroy = 0.5f;
            Destroy(gameObject, timeToDestroy);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("col.gameObject.name");
            Destroy(gameObject);
        }

        private void Update()
        {
            float speed = 15f;
            transform.position += _direction * Time.deltaTime * speed;
        }
    }
}
