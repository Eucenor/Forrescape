using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AnswerPiranha : MonoBehaviour
{
    [SerializeField]
    private GameObject inputResponse;
    [SerializeField]
    private TMPro.TMP_InputField inputField;
    [SerializeField]
    private string answerToRiddle;
    [SerializeField]
    private Button correctAnswerButton;
    [SerializeField]
    private Button wrongAnswerbutton;
    [SerializeField]
    private DialogueTrigger snailDialogue;
    private bool hasAnswered = false;
    private void OnEnable()
    {
        DialogueManager.OnEndDialogue += AnswerDialogue;   
    }
    public void OnAnswer()
    {
        if (!hasAnswered)
        {
            print("inside onAnswer");
            if (inputField.text.ToLower() == answerToRiddle)
            {
                correctAnswerButton.onClick.Invoke();
            }
            else
            {
                wrongAnswerbutton.onClick.Invoke();
            }

            this.hasAnswered = true;
            inputResponse.gameObject.SetActive(false);
        }
    }
    private void AnswerDialogue(string name)
    {
        string nameOfAnimal = name.ToLower();
        print("nameOfAnimal:"+nameOfAnimal);
        switch (nameOfAnimal) {

            case "plint":
                {
                    
                    AnswerToPlint();
                    break;
                }
            case "snaill":
                {
                   RemoveSnailButton();
                    break;
                }
        }
    }
    private void AnswerToPlint()
    {
        if (!hasAnswered)
        {
            print("turning on inputfield");
            inputResponse.gameObject.SetActive(true);
        }
    }
    private void RemoveSnailButton()
    {
        snailDialogue.dialogue.sentences = new string[2];
        snailDialogue.dialogue.sentences[0] = "I think you should go back and visit your grandparents's grave once more before you venture forth...";
        snailDialogue.dialogue.sentences[1] = "...";
    }
    private void OnDestroy()
    {
        DialogueManager.OnEndDialogue -= AnswerDialogue;
    }
}
