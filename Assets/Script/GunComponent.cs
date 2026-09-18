using UnityEngine;

public class GunComponent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletMaxImpulse = 100.0f;
    public float maxChargeTime = 3.0f;
    private float chargeTime = 0.0f;
    private bool isCharging = false;

    void Update() {
        //Adding logic to player keeping input down
        if (Input.GetButtonDown("Fire1"))
        {
            chargeTime = 0;
            isCharging = true;
        }
        
        if (Input.GetButton("Fire1")) {
            chargeTime += Time.deltaTime;
            chargeTime = Mathf.Clamp(chargeTime, 0, maxChargeTime);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            ShootBullet();
            isCharging=false;
        }
    }

    void ShootBullet() {
        GameObject bulet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody rb = bulet.GetComponent<Rigidbody>();

        //Changing the euqation so that it adds an impulse tahat follows charge time

        float bulletImpulse = (chargeTime / maxChargeTime) * bulletMaxImpulse;

        //An impulse is a force that you apply on a object in a single instant
        rb.AddForce(bulletSpawnPoint.forward * bulletImpulse, ForceMode.Impulse);
    }

   
}
