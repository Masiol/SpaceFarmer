using UnityEngine;

public class RotateObjectToCamera : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (mainCamera != null)
        {
            Vector3 directionToCamera = mainCamera.transform.position - transform.position;
            directionToCamera.y = 25f;
            Quaternion rotationToCamera = Quaternion.LookRotation(directionToCamera);
            transform.rotation = rotationToCamera;
        }
        else
        {
            return;
        }
    }
}