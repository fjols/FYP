using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerObject : NetworkBehaviour
{
    public GameObject PlayerPrefab;
    [SyncVar(hook = "OnPlayerNameChanged")]
    public string playerName = "Anonymous";

    void Start()
    {
        if(isLocalPlayer == false)
        {
            return;
        }
        Debug.Log("PLAYOBJECT::START: [SPAWNED UNIT].");
        CmdSpawnUnit();
    }

    void Update()
    {
        if(isLocalPlayer == false)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S KEY DOWN");
            CmdSpawnUnit();
        }
    }

    // Command functions require Cmd prefix.
    [Command]
    void CmdSpawnUnit()
    {
        GameObject go = Instantiate(PlayerPrefab); // Instatiate a player.
        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
    }
}
