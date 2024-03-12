using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectToThrowScript : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnObject;
    void Awake()
    {
        Instantiate(spawnObject, transform.position, Quaternion.identity);
    }
}
