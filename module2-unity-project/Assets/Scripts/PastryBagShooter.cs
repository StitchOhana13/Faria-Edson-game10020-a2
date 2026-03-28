using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class PastryBagShooter : MonoBehaviour, IHittable
{

    public GameObject VanillaIcingPrefab; // Drag your projectile prefab here in the Inspector
    public Transform VanillaShootPoint; // Drag your empty Firing Point object here
    public float shootForce = 1000f; // Adjust force as needed

    public UnityEvent<PastryBagShooter> OnShoot;

    public void Hit (GameObject gameObject)
    {
        //this.Shoot();
        OnShoot.Invoke(this);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Fire1")) // Fire1 is the default left mouse button/left control key
        //{
        //    Shoot();
        //}
    }

    
    public void Shoot(PastryBagShooter PBS)
    {
        // Instantiate the projectile at the spawn point's position and rotation
        GameObject bullet = Instantiate(VanillaIcingPrefab, VanillaShootPoint.position, VanillaShootPoint.rotation);

        // Get the Rigidbody component from the instantiated bullet
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // Add force in the forward direction of the spawn point
        rb.AddForce(VanillaShootPoint.forward * shootForce, ForceMode.Impulse); // Use ForceMode.Impulse for immediate push

     
    }
}
