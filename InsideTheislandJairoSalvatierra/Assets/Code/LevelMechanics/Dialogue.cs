using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField, TextArea (4,6)]private string[] dialogueLines;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    public GameObject infoPanel;
    private bool isInRange;
    private bool didDialogueStart;
    private int lineIndex;
    private float typingTime = 0.05f;
    private void Update()
    {
        if(isInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            if (!didDialogueStart)
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
    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        lineIndex = 0;
        Time.timeScale = 0;
        StartCoroutine(ShowLineCo());
    }
    private void NextDialogueLine()
    {
        lineIndex++;
        if(lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLineCo());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    private IEnumerator ShowLineCo()
    {
        dialogueText.text = string.Empty;
        foreach(char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            infoPanel.SetActive(true);
            isInRange = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            infoPanel.SetActive(false);
            isInRange = false;
        }

        
    }
}
