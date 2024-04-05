using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("laser"))
        {
            StartCoroutine(HitColorAndDisappear());
        }
    }

    private IEnumerator HitColorAndDisappear()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;

        // Wait for a short duration
        yield return new WaitForSeconds(0.075f);

        // Change the color back to white
        gameObject.GetComponent<Renderer>().material.color = Color.white;

        // Make the object disappear
        Destroy(gameObject);
    }
}
