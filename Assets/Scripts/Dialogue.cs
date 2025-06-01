using UnityEngine;
using TMPro;
using System.Collections;
public class Dialogue : MonoBehaviour
{
    [Header("Variables Privadas")]
    private int lineIndex;
    private bool playerInRange;
    private bool dialogueStarted;
    private float typingTime = 0.05f;

    [Header("Serializados")]
    //[SerializeField] GameObject dialogueMark;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField, TextArea(4 , 6)] private string[] dialogueLines;
    public bool PlayerInRange
    {
        get { return playerInRange; }
        set { playerInRange = value; }
    }

    // Update is called once per frame
    void Update()
    {
        /*if(playerInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogueStarted)
            {
                StartDialogue();
            }
            else if(dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }*/
        
    }
    private void StartDialogue()
    {
        dialogueStarted = true;
        dialoguePanel.SetActive(true);
        //dialogueMark.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }
    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        foreach(char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }
    private void NextDialogueLine()
    {
        lineIndex++;
        if(lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            dialogueStarted = false;
            dialoguePanel.SetActive(false);
            //dialogueMark.SetActive(true);
            Time.timeScale = 1f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            /*PlayerInRange = true;
            //dialogueMark.SetActive(true);
            Debug.Log("Se muestra indicador.");*/
            if (!dialogueStarted)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }
    }
    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInRange = false;
            //dialogueMark.SetActive(false);
            Debug.Log("Se oculta indicador .");
        }
    }*/
}
