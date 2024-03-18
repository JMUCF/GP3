using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShShEnergy : MonoBehaviour
{
    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        if (_player == null)
        {
            Debug.LogError("Player is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && _player )
        {
            _player.AddEnergy(1);

            Destroy(gameObject);
        }
    }
}
