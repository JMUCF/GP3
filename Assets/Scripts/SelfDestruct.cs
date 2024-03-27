using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(die());
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    public IEnumerator die()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
