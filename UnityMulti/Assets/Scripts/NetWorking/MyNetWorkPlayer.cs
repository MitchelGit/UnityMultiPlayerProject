using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class MyNetWorkPlayer:NetworkBehaviour
{
    [SerializeField] private TMP_Text DisplayNameText = null;
    [SerializeField] private Renderer DisplayRenderer = null;

    // these variables are hooked so when the server gets a request they get pushed 
    // to the clients automaticly
    [SyncVar(hook = nameof(CmdUpdateDisplayNameToClients))]
    [SerializeField] private string DisplayName = "Missing Name";
    [SyncVar(hook = nameof(CmdUpdateDisplayColorToClients))]
    [SerializeField] private Color DisplayColor;


    #region Server
    [Server]
    public void SetDisplayName(string newdisplayname)
    {
        DisplayName = newdisplayname;
    }
   
    [Server]
    public void SetDisplayColor(Color newdisplaycolor)
    {
        DisplayColor = newdisplaycolor;
     
    }
    #endregion


    #region client

   
    private void CmdUpdateDisplayNameToClients(string oldname, string newname)
    {
        DisplayNameText.text = newname;
    }
  
    private void CmdUpdateDisplayColorToClients(Color oldcolor, Color newcolor)
    {
        DisplayRenderer.material.color = newcolor;
    }
    #endregion

}
