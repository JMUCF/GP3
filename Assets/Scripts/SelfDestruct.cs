using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    private float delay = 0f;

    void Start()
    {
        if (gameObject.tag == "laser")
            delay = 5f;
        else if (gameObject.tag == "hitbox")
            delay = .15f;

        StartCoroutine(die());
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    public IEnumerator die()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
