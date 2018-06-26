using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour
{
    private const float maxHealth = 100.0f;
    private bool isAlive { get; set; }

    [SerializeField] private GameObject self;

    [SerializeField] private float currentHealth = maxHealth;

    private void Start()
    {
        isAlive = true;
    }

    public void TakeDamage(float _amount)
    {
        CmdTakeDamage(_amount);
    }


    #region COMMANDS
    /// <summary>
    /// 
    /// </summary>
    [Command]
    void CmdSetActive()
    {
        RpcSetActive();
    }

    [Command]
    private void CmdTakeDamage(float _amount)
    {
        RpcTakeDamage(_amount);
    }
    #endregion

    #region RPCs
    /// <summary>
    /// 
    /// </summary>
    [ClientRpc]
    private void RpcSetActive()
    {
        self.SetActive(false);
    }

    [ClientRpc]
    private void RpcTakeDamage(float _amount)
    {
        if (isServer == false) // server only allowed to change game state
            return;

        currentHealth -= _amount;

        if (currentHealth <= 0)
        {
            Debug.Log(this.gameObject.name + " " + "is dead!!");
            // player is dead do we need to respawn?
            //RpcSetActive();
        }
    }
    #endregion
}
