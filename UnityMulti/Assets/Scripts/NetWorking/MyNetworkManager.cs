using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager :NetworkManager
{
    [SerializeField] private GameObject UnitSpawnerPrefab = null;
    [SerializeField] private MyNetWorkPlayer MyPlayer;
    public MyNetWorkPlayer GetMyPlayer()
    {
        return MyPlayer;
    }

    public override void OnServerAddPlayer(NetworkConnection conn)
    {

        base.OnServerAddPlayer(conn);
      // when we add a player we also spawn a unitspawner
      GameObject SpawnerInstance =  Instantiate(UnitSpawnerPrefab, conn.identity.transform.position, conn.identity.transform.rotation);
      NetworkServer.Spawn(SpawnerInstance, conn);
      MyPlayer = conn.identity.GetComponent<MyNetWorkPlayer>();





       
        //player.SetDisplayName($"Player{numPlayers}");
        //Color displaycolor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        //player.SetDisplayColor(displaycolor);


    }
    // Start is called before the first frame update

   
}
