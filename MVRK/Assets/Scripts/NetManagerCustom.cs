using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MsgTypes
{
    public const short PlayerPrefab = MsgType.Highest + 1;

    public class PlayerPrefabMsg : MessageBase
    {
        public short controllerID;
        public short prefabIndex;
    }
}

public class NetManagerCustom : NetworkManager
{
    [SerializeField] string ipAddr = "192.168.0.28";
    [SerializeField] int port = 7777;

    // in the Network Manager component, you must put your player prefabs 
    // in the Spawn Info -> Registered Spawnable Prefabs section 
    public short playerPrefabIndex;
    public GameObject canv = null;

    public override void OnStartServer()
    {
        NetworkServer.RegisterHandler(MsgTypes.PlayerPrefab, OnResponsePrefab);
        base.OnStartServer();
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        client.RegisterHandler(MsgTypes.PlayerPrefab, OnRequestPrefab);
        base.OnClientConnect(conn);
    }

    private void OnRequestPrefab(NetworkMessage netMsg)
    {
        MsgTypes.PlayerPrefabMsg msg = new MsgTypes.PlayerPrefabMsg();
        msg.controllerID = netMsg.ReadMessage<MsgTypes.PlayerPrefabMsg>().controllerID;
        msg.prefabIndex = playerPrefabIndex;
        client.Send(MsgTypes.PlayerPrefab, msg);
    }

    private void OnResponsePrefab(NetworkMessage netMsg)
    {
        MsgTypes.PlayerPrefabMsg msg = netMsg.ReadMessage<MsgTypes.PlayerPrefabMsg>();
        playerPrefab = spawnPrefabs[msg.prefabIndex];
        base.OnServerAddPlayer(netMsg.conn, msg.controllerID);
        Debug.Log(playerPrefab.name + " spawned!");
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        MsgTypes.PlayerPrefabMsg msg = new MsgTypes.PlayerPrefabMsg();
        msg.controllerID = playerControllerId;
        NetworkServer.SendToClient(conn.connectionId, MsgTypes.PlayerPrefab, msg);
    }

    public void SetPort()
    {
        NetworkManager.singleton.networkPort = port;
    }

    public void SetAddress()
    {
        NetworkManager.singleton.networkAddress = ipAddr;
    }

    public void StartupHost()
    {
        SetPort();
        NetworkManager.singleton.StartHost();

    }

    public override NetworkClient StartHost()
    {
        if (canv != null)
        {
            canv.SetActive(false);
        }
        return base.StartHost();

    }

    public void JoinGame()
    {
        SetAddress();
        SetPort();
        NetworkManager.singleton.StartClient();
        if (canv != null)
        {
            canv.SetActive(false);
        }

    }

    // The index will be the number from the registered spawnable prefabs that 
    // you want for your player
    public void SetPrefabIndex(short _index)
    {
        playerPrefabIndex = _index;
    }
}