using UnityEngine;
using System.Collections;

public class CleanUp : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter");
        if (other.gameObject.name == "Platform")
        {
            PoolManager.Instance.PoolObject(other.gameObject);
        }
    }

}
