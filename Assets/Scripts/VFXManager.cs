using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public GameObject particleObject;

    public void PlayVFX(Vector3 spawnPosition)
    {
        Instantiate(particleObject, spawnPosition, Quaternion.identity);
    }
}
