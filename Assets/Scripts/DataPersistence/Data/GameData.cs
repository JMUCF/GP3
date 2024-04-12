using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public float currentEnergy;

    public Vector3 playerPosition;

    public GameData()
    {
        this.currentEnergy = 0;
        playerPosition = Vector3.zero;
    }
}
