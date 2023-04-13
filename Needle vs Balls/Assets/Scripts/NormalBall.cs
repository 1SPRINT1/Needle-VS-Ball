using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBall : MonoBehaviour
{
    public GameObject hitEffector;
    public AudioSource AudikUdar;

    private void Start()
    {
        AudikUdar = GetComponent<AudioSource>();   
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {        
                Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Prepik"))
        {
            GameObject effect = Instantiate(hitEffector, transform.position, Quaternion.identity);
            Destroy(effect, 3f);
            AudikUdar.Play();
        }
    }
}
