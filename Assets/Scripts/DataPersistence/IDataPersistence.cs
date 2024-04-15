using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistence
{
    void LoadGame(GameData data);

    void SaveGame(ref GameData data);
}
