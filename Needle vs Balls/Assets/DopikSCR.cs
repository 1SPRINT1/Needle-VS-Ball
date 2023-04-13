using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DopikSCR : MonoBehaviour
{
    public GameObject hitEffector;
    public GameObject hitEffector2;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject effect = Instantiate(hitEffector, transform.position, Quaternion.identity);
            Destroy(effect,3f);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Prepik"))
        {
            GameObject effect2 = Instantiate(hitEffector2, transform.position, Quaternion.identity);
            Destroy(effect2, 3f);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            Destroy(gameObject);
        }
    }
}
