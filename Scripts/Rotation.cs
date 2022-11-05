using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    public float us;
      public void Update()
    {
      
        transform.RotateAround(Vector3.zero, Vector3.up, us * Time.deltaTime);
        

        // transform.Rotate((Vector3.right * RotationSpeed) * (Time.deltaTime * dumpAmt),Space.Self);
    }
}
