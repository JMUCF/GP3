using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShShEnergy : MonoBehaviour
{
    private Player _player;
    public GameObject child;
    private bool childActive;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        if (_player == null)
        {
            Debug.LogError("Player is null");
        }

        childActive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && _player && childActive)
        {
            _player.AddEnergy(1);

            child.SetActive(false);
            childActive = false;
            StartCoroutine("RespawnChild");
        }
    }

    private IEnumerator RespawnChild()
    {
        yield return new WaitForSeconds(10f);
        child.SetActive(true);
        childActive = true;
    }
}
