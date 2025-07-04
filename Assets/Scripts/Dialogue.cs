using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Dialogue : MonoBehaviour
{
    [Header("Variables Privadas")]
    private int lineIndex;
    private bool playerInRange;
    private bool dialogueStarted = false;
    private float typingTime = 0.05f;

    [Header("Serializados")]
    [SerializeField] GameObject BlackScreen;
    //[SerializeField] GameObject dialogueMark;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField, TextArea(4 , 6)] private string[] dialogueLines;
    public bool PlayerInRange
    {
        get { return playerInRange; }
        set { playerInRange = value; }
    }
    private void StartDialogue()
    {
        dialogueStarted = true;
        dialoguePanel.SetActive(true);
        BlackScreen.SetActive(true);
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
        yield return new WaitForSecondsRealtime(2);
        NextDialogueLine();
    }
    private IEnumerator ChangeScene()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(9);
    }
    private void NextDialogueLine()
    {
        lineIndex++;
        if(lineIndex < dialogueLines.Length - 1)
        {
            StartCoroutine(ShowLine());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInRange = true;
            //dialogueMark.SetActive(true);
            Debug.Log("Se muestra indicador.");
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
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInRange = false;
            //dialogueMark.SetActive(false);
            Debug.Log("Se oculta indicador .");
        }
    }
}
