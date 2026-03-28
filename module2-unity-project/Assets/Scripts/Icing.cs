using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icing : MonoBehaviour
{
    //public GameObject VanillaCake;
    //public GameObject ChocolateCake;
    //public GameObject StrawberryCake;

    public float fireSpeed;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + fireSpeed * Time.deltaTime);
    }



   
}
