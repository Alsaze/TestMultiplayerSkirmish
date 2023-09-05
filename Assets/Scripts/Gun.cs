using System.Collections;
using Default;
using Mirror;
using UnityEngine;

public class Gun : NetworkBehaviour
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

    public void TryToShot()
    {
        if (_canShot)
        {
            Debug.Log("Shot");
            Shot();
        }
    }
    private void Shot()
    {
        _canShot = false;
        
        CreateBullet();
        
        OnReloud();
    }

    [Command]
    private void CreateBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab, muzzle.transform.position,
            belfry.transform.rotation * bulletPrefab.transform.rotation);
        
        NetworkServer.Spawn(newBullet);//Spawn on server
        
        newBullet.GetComponent<Bullet>().Setup(ShotDirection());//make a direction and controll a bullet
    }

    private void OnReloud()
    {
        if (_isRelouding == false)
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
}
