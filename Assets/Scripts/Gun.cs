using System.Collections;
using Default;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject belfry;
    [SerializeField] private GameObject muzzle;
    
    private bool _canShot = true;
    private bool _isRelouding = false;

    private Vector2 ShotDirection()
    {
        return muzzle.transform.position - belfry.transform.position;
    }

    private void TryToShot()
    {
        if (_canShot)
        {
            Shot();
        }
    }

    private void Shot()
    {
        _canShot = false;
        
        GameObject newBullet = Instantiate(bulletPrefab, muzzle.transform.position,
            belfry.transform.rotation * bulletPrefab.transform.rotation);
        newBullet.GetComponent<Bullet>().Setup(ShotDirection());
            
        OnReloud();
    }

    private void OnReloud()
    {
        if (_isRelouding==false)
        {
            StartCoroutine("ReloudTimer");
        }
    }

    private IEnumerator ReloudTimer()
    {
        _isRelouding = true;
        float shotColwdown = 1f;
        yield return new WaitForSeconds(shotColwdown);
        _canShot = true;
        _isRelouding = false;
    }

    private void OnEnable()
    {
        FixedJoystick.OnShot += TryToShot;
    }

    private void OnDisable()
    {
        FixedJoystick.OnShot -= TryToShot;
    }
}
