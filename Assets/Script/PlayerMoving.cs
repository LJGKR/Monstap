using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public Transform otherObject;
    private void Update()
    {
        Vector3 otherRotation = otherObject.rotation.eulerAngles;
        Vector3 newRotation = new Vector3(transform.rotation.eulerAngles.x, otherRotation.y, transform.rotation.eulerAngles.z);
        transform.rotation = Quaternion.Euler(newRotation);
    }
}
