using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icing : MonoBehaviour
{
    Collider triggerCollider;

    Rigidbody icingRigidbody;
    private void Awake()
    {
        Collider[] colliderComponents = GetComponents<Collider>();
        foreach (Collider collider in colliderComponents)
        {
            if (collider.isTrigger)
            {
                triggerCollider = collider;
                break;
            }
        }

        icingRigidbody = GetComponent<Rigidbody>();

        // the rock is initially set up as kinematic, so that
        // when it is in the player's hand, it stays parented and 
        // does not move with physics
        icingRigidbody.isKinematic = true;
    }

    private void Start()
    {
        // the rock is initially disabled. swinging a rock at an
        // Hittable object does nothing. you might change this design choice
        EnableHitbox(0);
    }

    public void Throw(Vector3 direction, float force)
    {
        EnableHitbox(1);

        // clearing the Rock's parent is important, because otherwise it stays
        // attached to the Character arm
        transform.parent = null;

        Vector3 position = transform.position;
        transform.position = new Vector3(position.x, 1.5f, position.z);

        // no longer kinematic since we want it to move with its velocity parameters
        icingRigidbody.isKinematic = false;

        icingRigidbody.velocity = Vector3.zero;
        icingRigidbody.angularVelocity = Vector3.zero;

        icingRigidbody.velocity = direction.normalized * force;
    }

    public void EnableHitbox(int value)
    {
        triggerCollider.enabled = value == 1 ? true : false;
    }

    // technically this code is repeated for all "Weapon" objects
    // this can be improved with something called inheritance
    // both Shovel and Rock could inherit Weapon - but this introduces more complications
    // with Start(). namely, reflection and overriding virtual functions
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IHittable>() != null)
        {
            IHittable toggle = other.GetComponent<IHittable>();
            toggle.Hit(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
