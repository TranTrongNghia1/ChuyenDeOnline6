using UnityEngine;
using Fusion;
using System.Collections.Generic;
public class Spawn : SimulationBehaviour, IPlayerJoined
{
    public GameObject PlayerPrefab;
    public void PlayerJoined(PlayerRef player)
    {
        var position = new Vector3(0, 2, 0);
        Runner.Spawn(PlayerPrefab, position, Quaternion.identity);
    }
}

