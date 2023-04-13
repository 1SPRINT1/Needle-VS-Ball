using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public PlayerMove PM;
    public GameObject hitEffector;
    public GameObject hitEffector2;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameObject effect = Instantiate(hitEffector, transform.position, Quaternion.identity);
            Destroy(effect,3f);

        }

        if (other.gameObject.CompareTag("Prepik"))
        {
                GameObject effect2 = Instantiate(hitEffector2, transform.position, Quaternion.identity);
                Destroy(effect2, 3f);
        }
    }
}
