using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("laser"))
        {
            StartCoroutine(hitColor());
        }
    }

    public IEnumerator hitColor()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(.075f);
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
