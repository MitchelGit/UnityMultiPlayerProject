using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnitCommands : MonoBehaviour
{

    [SerializeField] private UnitSelectionHandler _UnitSelectionHandler;
    private Camera MainCamera;
    [SerializeField] private LayerMask layermask = new LayerMask();
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
    }

    private void Update()
    {
        if (!Mouse.current.rightButton.wasPressedThisFrame) { return; }

        Ray ray = MainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if(!Physics.Raycast(ray,out RaycastHit hit,Mathf.Infinity, layermask)) {return;}


        TryMove(hit.point);
    }


    private void TryMove(Vector3 point)
    {

        foreach(Unit unit in _UnitSelectionHandler.SelectedUnitList)
        {
            unit.GetUnitMovement().CmdMove(point);
        }

    }
}
