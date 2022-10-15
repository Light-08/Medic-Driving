using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject toFollow;

    // This thing's (Camera's) position must be the same as that of the car.
    void LateUpdate()
    {
        transform.position = toFollow.transform.position + new Vector3 (0, 0, -10);
    }
}
