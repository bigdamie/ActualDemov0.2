using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTransfer : MonoBehaviour
{
    [SerializeField] private string roomToLoad;
    [SerializeField] private string playerTag;
    [SerializeField] private VectorValue playerVector, playerSpawnPos;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(playerTag) && !other.isTrigger)
        {
            playerVector.value = playerSpawnPos.defaultValue;
            LoadRoom();
           

        }
    }


    void LoadRoom()
    {
        SceneManager.LoadScene(roomToLoad);
    }
}
