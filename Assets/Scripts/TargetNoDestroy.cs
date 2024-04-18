using System.Collections;
using UnityEngine;

public class TargetNoDestroy : MonoBehaviour
{
    public Material redMaterial;
    public Material whiteMaterial;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("laser"))
        {
            StartCoroutine(HitColor());
        }
    }

    private IEnumerator HitColor()
    {
        GetComponent<Renderer>().material = redMaterial;

        // Wait for a short duration
        yield return new WaitForSeconds(0.075f);

        // Change the material back to white
        GetComponent<Renderer>().material = whiteMaterial;
    }
}
