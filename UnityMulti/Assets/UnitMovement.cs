using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class UnitMovement : NetworkBehaviour
{
     [SerializeField] private NavMeshAgent MyAgent;
     private Camera MainCamera;

   

    #region client
   
    #endregion






    // this is the server command that we call from the client
    #region Server
    [Command]
    public void CmdMove(Vector3 ClickPosition)
    {
        if (!NavMesh.SamplePosition(ClickPosition, out NavMeshHit hit, 1, NavMesh.AllAreas)) { return; }
        MyAgent.SetDestination(hit.position);

    }
    #endregion
}
