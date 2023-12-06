using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidersFarm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DisableChildMeshColliders();
    }

    private void DisableChildMeshColliders()
    {
        // Disable MeshColliders for all children
        MeshCollider[] childMeshColliders = GetComponentsInChildren<MeshCollider>();
        foreach (MeshCollider childCollider in childMeshColliders)
        {
            childCollider.enabled = false;
        }
    }
    public void EnableChildMeshColliders()
    {
        // Enable MeshColliders for all children
        MeshCollider[] childMeshColliders = GetComponentsInChildren<MeshCollider>();
        foreach (MeshCollider childCollider in childMeshColliders)
        {
            childCollider.enabled = true;
        }
    }
}
