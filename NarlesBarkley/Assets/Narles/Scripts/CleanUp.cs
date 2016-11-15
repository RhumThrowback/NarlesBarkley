using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CleanUp : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ring")
        {
            PoolManager.Instance.PoolObject(other.gameObject);
            GameManager.Instance.ringsInLevel.RemoveAt(0);
        }
    }
}
