using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BulletPrafab;
    public float BulletSpeed = 10;
    public Transform Spawn;
    public AudioSource ShotSound;
    public GameObject Flash;
    public float ShotPeriod = 0.2f;
    private float _timer;
    public ParticleSystem ShotSmoke;

    private void Update()
    {
        _timer += Time.unscaledDeltaTime;

        if (_timer >= ShotPeriod)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                PistolFire1();
                _timer = 0;

            }
        }

    }
    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }
    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }
    public virtual void PistolFire1()
    {
        GameObject newBullet = GameObject.Instantiate(BulletPrafab, Spawn.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = Spawn.forward * BulletSpeed;
        ShotSound.Play();
        Flash.SetActive(true);
        Invoke("FlashHide", 0.2f);
        ShotSmoke.Play();

    }

    public void FlashHide()
    {
        Flash.SetActive(false);
    }

    public virtual void AddNewGunOrAmmo(int numberOfAmmo)
    {

    }
}
