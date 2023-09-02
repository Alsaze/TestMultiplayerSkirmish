using System;
using Mirror;
using UnityEngine;

namespace Default
{
    public class Bullet : MonoBehaviour
    {
        private Vector3 _direction;

        [Server]
        public void Setup(Vector2 direction)
        {
            _direction = direction;
            float timeToDestroy = 0.5f;
            Destroy(gameObject, timeToDestroy);
        }
        [Server]
        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("col.gameObject.name");
            Destroy(gameObject);
        }
        [Server]
        private void Update()
        {
            float speed = 15f;
            transform.position += _direction * Time.deltaTime * speed;
        }
    }
}
