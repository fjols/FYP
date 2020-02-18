using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/*
            ---PLAYER UNIT---
        A playerunit is a unit which is controlled by a player.
*/

public class PlayerUnit : NetworkBehaviour
{
    Vector3 vel;
    Vector3 bestGuessPosition;
    float myLatency;
    float latencySmoothingFactor = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hasAuthority == false)
        {
            bestGuessPosition = bestGuessPosition + (vel * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, bestGuessPosition, Time.deltaTime * latencySmoothingFactor);
            return;
        }
        transform.Translate(vel * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.transform.Translate(0, 1, 0);
        }
    }
}
