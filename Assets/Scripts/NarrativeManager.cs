using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeManager : MonoBehaviour
{
    public GameObject text;
    public GameObject previousText;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            previousText.SetActive(false);
            StartCoroutine("Text"); 
        }
    }

    private IEnumerator Text()
    {
        text.SetActive(true);
        yield return new WaitForSeconds(5f);
        text.SetActive(false);
        gameObject.SetActive(false);
    }
}
