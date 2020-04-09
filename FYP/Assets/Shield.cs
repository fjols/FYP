using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/*
    This class will allow the player to block projectiles from enemies.
    The shield will have a timer so it can't be used for too long and it
    will be destroyed after a certain amount of bullets have hit it.
*/

public class Shield : NetworkBehaviour
{
    public string m_sButton; // Button to activate the shield.
    public Transform m_shieldPos; // Position of the shield.
    public GameObject m_shield; // The gameobject of the shield.

    void Update()
    {
        if(Input.GetButtonDown(m_sButton))
        {
            ActivateShield();
        }
    }

    void ActivateShield()
    {
        if(isLocalPlayer)
        {
            //m_shieldPos.position = GameObject.FindWithTag("PlayerUnit").transform.position;
            CmdSpawn(GameObject.FindWithTag("PlayerUnit").transform.position);
        }
    }

    [Command]
    void CmdSpawn(Vector3 pos)
    {
       // pos = GameObject.FindWithTag("PlayerUnit").transform.position;
        GameObject go = Instantiate(m_shield, pos, Quaternion.identity); // Create a gameobject of the shield.
        NetworkServer.SpawnWithClientAuthority(go, base.connectionToClient); // Spawn it.
    }
}
