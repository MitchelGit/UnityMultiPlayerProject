using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnitSelectionHandler : MonoBehaviour
{

    private Camera MainCamera;
    public List<Unit> SelectedUnitList {get;} = new List<Unit>();
    [SerializeField] private LayerMask layermask = new LayerMask();
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
    }





    private void Update()
    {
        
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            NewSelectionDrag();
        }

        else if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            ClearSelectionArea();
        }


    }


    private void NewSelectionDrag()
    {
        foreach (Unit _selectedUnits in SelectedUnitList)
        {
            _selectedUnits.DeSelect();
           
        }
        SelectedUnitList.Clear();

    }

    private void ClearSelectionArea()
    {
        Ray ray = MainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (!Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layermask)) { return; }
        if(!hit.collider.TryGetComponent<Unit> (out Unit unit)) { return; }
        if (!unit.hasAuthority) { return; }
  
          
                SelectedUnitList.Add(unit);
                foreach (Unit _selectedUnits in SelectedUnitList)
        {
            _selectedUnits.Select();
        }




    }

}
