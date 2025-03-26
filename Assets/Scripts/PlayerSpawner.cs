using UnityEngine;
using Fusion;
public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject PlayerPrefab;
    public void PlayerJoined(PlayerRef player)
    {
        if (player == Runner.LocalPlayer)
        {
            var position = new Vector3(0, 1, 0);
            Runner.Spawn(PlayerPrefab, position, Quaternion.identity);
        }
    }
}
