using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.EventSystems;

public class UnitSpawner : NetworkBehaviour , IPointerClickHandler

{
    [SerializeField] private GameObject UnitToSpawnPrefab = null;
    [SerializeField] Transform UnitSpawnPosition;

   
    #region Server
    [Command]
    private void CmdSpawnUnit()
    {
        GameObject unitInstane = Instantiate(UnitToSpawnPrefab, UnitSpawnPosition.position, UnitSpawnPosition.rotation);
        NetworkServer.Spawn(unitInstane, connectionToClient);
    }



    #endregion



    #region client

    // if we as a client press on the spawner and we have autority over it we call the cmd spawn on the srver 
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button != PointerEventData.InputButton.Left) { return;}
        if (!hasAuthority) { return; }
        CmdSpawnUnit();
    }


    #endregion
}

