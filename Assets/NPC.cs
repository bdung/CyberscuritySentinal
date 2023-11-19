using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject dialogPanel;
    public Text dialogText;

    public string[] dialog;
    private int index;
    public float wordSpeed;
    public bool playerIsClose;

    void Update(){
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose){
            if(dialogPanel.activeInHierarchy){
                zeroText();
            }else{
                dialogPanel.SetActive(true);
                StartCoroutine((string)Typing());
            }
        }
    }

    public void zeroText(){
        dialogText.text = "";
        index = 0;
        dialogPanel.SetActive(false);
    }
    IEnumerable Typing(){
        foreach(char letter in dialog[index].ToCharArray()){
            dialogText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerIsClose = true;
        }
    }
    public void NextLine(){
        if(index < dialog.Length - 1){
            index++;
            dialogText.text = "";
            StartCoroutine((string)Typing());

            
        }
    }
    public void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerIsClose = false;
                zeroText();

        }
    }
}
