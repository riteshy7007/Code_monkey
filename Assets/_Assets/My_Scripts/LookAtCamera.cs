using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookAtCamera : MonoBehaviour
{
    
    private enum Mode
    {
        LookAtCamera,
        LookAtinverseCamera,
        LookForward,
        lookforwardinverse
    }

[SerializeField] private Mode mode;

private void LateUpdate()
{
    switch (mode)
    {
        case Mode.LookAtCamera:
            transform.LookAt(Camera.main.transform);
            break;
        case Mode.LookAtinverseCamera:
            Vector3 dirFromCamera = transform.position - Camera.main.transform.position;
            transform.LookAt(transform.position + dirFromCamera);
            break;
        case Mode.LookForward:
            transform.forward = Camera.main.transform.forward;
            break;
        case Mode.lookforwardinverse:
            transform.forward = -Camera.main.transform.forward;
            break;
    }



}
}
