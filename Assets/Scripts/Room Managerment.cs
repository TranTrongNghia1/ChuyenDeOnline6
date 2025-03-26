using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityStandardAssets.Characters.FirstPerson;

public class RoomManagerment : MonoBehaviourPunCallbacks
{
    public GameObject player;
    public Transform spawnPoint;

    void Start()
    {
        Debug.Log("Connecting....");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Connected to Server");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("We're in the lobby, joining/creating a room...");
        PhotonNetwork.JoinOrCreateRoom("test", new RoomOptions { MaxPlayers = 10 }, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Joined Room! Now we can instantiate the player.");

        // Chỉ instantiate khi đã vào phòng
        GameObject _player = PhotonNetwork.Instantiate("Player", spawnPoint.position, Quaternion.identity);

        _player.GetComponent<PlayerSetup>().IsLocalPLayer();
    }
}
