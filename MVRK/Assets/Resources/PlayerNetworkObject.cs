using UnityEngine;
using UnityEngine.Networking;
public class PlayerNetworkObject : NetworkBehaviour
{
    #region VARIABLES

    [SerializeField] private GameObject PlayerUnitPrefab = null;

    #endregion

    #region MonoBehaviour Callbacks
    private string myName;
    private int count = 0;

    void Start()
    {
        if (isLocalPlayer == false)
        {
            Debug.Log("is local player");
            return;
        }

        if (isServer)
            Debug.Log("is Server");
        else if (isClient)
        {
            Debug.Log("is Client");
           // Network.Connect("10.242.119.4", 777);
        }


        CmdSpawn();
    }

    void Update()
    {
        if (isLocalPlayer == false) return;

        
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (myName == string.Empty)
            {
                myName = "AR: " + (++count);
                Debug.Log("PlayerNetworkObject::Update -- New name: " + myName);
            }
        }

    }
    #endregion

    #region COMMANDS

    [Command]
    public void CmdSpawn()
    {
        GameObject self = Instantiate(PlayerUnitPrefab);

        NetworkServer.SpawnWithClientAuthority(self, connectionToClient);
  
        
    }
    


    #endregion
}
