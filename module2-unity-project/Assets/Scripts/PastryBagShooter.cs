using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PastryBagShooter : MonoBehaviour
{

    Vector3 GetPastryBagPoint()
    {
        Ray ray = 
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit.point;
        }
        return Vector3.zero;
    }

}
