using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public GameObject particleObject;
    public GameObject switchVFX;

    public void PlayVFX(Vector3 spawnPosition)
    {
        Instantiate(particleObject, spawnPosition, Quaternion.identity);
    }

    public void PlaySwitchVFX(Vector3 spawnPosition)
    {
        Instantiate(switchVFX, spawnPosition, Quaternion.identity);
    }
}
