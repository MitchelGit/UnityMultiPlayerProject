using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class RtsPlayer :NetworkBehaviour
{

    [SerializeField] private List<Unit> MyUnits = new List<Unit>();
    // Start is called before the first frame update


    #region Server
    public override void OnStartServer()
    {
        Unit.ServerOnUnitSpawned += ServerHandleUnitSpawned;
        Unit.ServerOnUnitDeSpawned += ServerHandleUnitDeSpawned;
    }

    public override void OnStopServer()
    {
        Unit.ServerOnUnitSpawned -= ServerHandleUnitSpawned;
        Unit.ServerOnUnitDeSpawned -= ServerHandleUnitDeSpawned;

    }


    private void ServerHandleUnitSpawned(Unit _unit)
    {

        if(_unit.connectionToClient.connectionId != connectionToClient.connectionId) { return; }
        MyUnits.Add(_unit);

    }
    private void ServerHandleUnitDeSpawned(Unit _unit)
    {
        if (_unit.connectionToClient.connectionId != connectionToClient.connectionId) { return; }
        MyUnits.Remove(_unit);
    }
    #endregion



    #region client
    public override void OnStartClient()
    {
        if (!isClientOnly) { return; }
        Unit.AuthorityUnitSpawned += AuthorityHandleUnitSpawned;
        Unit.AuthorityUnitDeSpawned += AuthorityHandleUnitDeSpawned;
    }

    public override void OnStopClient()
    {
        if (!isClientOnly) { return; }
        Unit.AuthorityUnitSpawned -= AuthorityHandleUnitSpawned;
        Unit.AuthorityUnitDeSpawned -= AuthorityHandleUnitDeSpawned;
    }

    private void AuthorityHandleUnitSpawned(Unit _unit)
    {

        if (!hasAuthority) { return; }
        MyUnits.Add(_unit);

    }
    private void AuthorityHandleUnitDeSpawned(Unit _unit)
    {
        if (!hasAuthority) { return; }
        MyUnits.Remove(_unit);
    }
    #endregion
}
