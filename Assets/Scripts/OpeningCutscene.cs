using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class OpeningCutscene : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    public CinemachinePathBase track1;
    public CinemachinePathBase track2;
    public CinemachineDollyCart myDollyCart;

    void Start()
    {
        cam.GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("hit collider");
        cam.m_Priority = 1;

        if(gameObject.name == "Trigger5")
        {
            myDollyCart.m_Path = track2;
            myDollyCart.m_Position = 0f;
        }
    }
}
