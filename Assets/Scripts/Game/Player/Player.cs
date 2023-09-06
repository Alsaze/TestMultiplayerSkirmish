using System;
using Mirror;
using UnityEngine;

namespace Default
{
    public class Player : NetworkBehaviour
    {
        private int _hp;
        private Bullet _bullet;
        private bool _isAuthority = false;
        
        private void Start()
        {
            _hp = 3;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (_isAuthority)
            {
                return;
            }
            if (col.gameObject.CompareTag("Bullet"))
            {
                _bullet = col.GetComponent<Bullet>();
                CalculateDamage();
            }
        }

        private void CalculateDamage()
        {
            _hp -= _bullet.Damage;
            ValidateHp();
        }

        private void ValidateHp()
        {
            if (_hp == 0)
            {
                Lose();
            }
        }

        private void Lose()//Temp method, must to be exist in class GameManager
        {
            Debug.Log("Death");
            Destroy(gameObject,0.1f);
        }

        public override void OnStartAuthority()
        {
            _isAuthority = true;
        }
    }
}