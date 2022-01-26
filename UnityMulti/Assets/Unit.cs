using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Events;
using System;

public class Unit :NetworkBehaviour
{
    [SerializeField] private UnitMovement unitmovement = null;
    //events
    [SerializeField] private UnityEvent OnSelectUnit;
    [SerializeField] private UnityEvent OnDeselectUnit;


    public static event Action<Unit> ServerOnUnitSpawned;
    public static event Action<Unit> ServerOnUnitDeSpawned;


    //client events 
    public static Action<Unit> AuthorityUnitSpawned;
    public static Action<Unit> AuthorityUnitDeSpawned;



    #region server

    //when a unit gets spawned on the server we drigger this action , so we can sub into it on other scripts
    [Server]
    public override void OnStartServer()
    {
        ServerOnUnitSpawned?.Invoke(this);

    }
    [Server]

    public override void OnStopServer()
    {
        ServerOnUnitDeSpawned?.Invoke(this);

    }
    #endregion




    private void Start()
    {
        
    }




    public UnitMovement GetUnitMovement()
    {
        return unitmovement;
    }
    // Start is called before the first frame update





    #region Client


    public override void OnStartClient()
    {
        if(!isClientOnly || !hasAuthority) { return; }
        AuthorityUnitSpawned?.Invoke(this);
    }

    public override void OnStopClient()
    {
        if (!isClientOnly || !hasAuthority) { return; }

        AuthorityUnitDeSpawned?.Invoke(this);
    }








    [Client]
    public void Select() {
        if (!hasAuthority) { return; }
        OnSelectUnit?.Invoke();
    
    }

    [Client]
    public void DeSelect() {
        if (!hasAuthority) { return; }
        OnDeselectUnit?.Invoke();
    }




    #endregion
}
