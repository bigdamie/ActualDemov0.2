using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameDialogue : MonoBehaviour
{
    [SerializeField] GameObject dialogueBox;

    private void Update()
    {
        if(Input.GetButtonDown("Check") ||
            Input.GetButtonDown("Weapon Attack") ||
            Input.GetButtonDown("Pause") )
        {
            StartGame();
        }

    }

    public void StartGame()
    {
        dialogueBox.SetActive(false);
        Destroy(this.gameObject);
    }
}
