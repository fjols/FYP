using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerObject : NetworkBehaviour
{
    public GameObject PlayerPrefab;

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
        
    }

    // Command functions require Cmd prefix.
    [Command]
    void CmdSpawnUnit()
    {
        GameObject go = Instantiate(PlayerPrefab); // Instatiate a player.
        NetworkServer.Spawn(go); // Spawn it using the network.
    }
}
