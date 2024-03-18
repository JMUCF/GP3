using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugStuff : MonoBehaviour
{
    public TMP_Text playerSpeedText;
    public GameObject player;
    private float playerSpeed;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        playerSpeed = rb.velocity.magnitude;
        playerSpeedText.text = playerSpeed.ToString();
    }
}
