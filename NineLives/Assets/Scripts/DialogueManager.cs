using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue (DialogueObject dialogue)
    {
        Debug.Log("Starting convo "+ dialogue.name);

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

   public void DisplayNextSentence()
    {
        if (sentences.Count != 0)
        {
            string sentence = sentences.Dequeue();
            Debug.Log(sentence);
        }
        else 
        {
            EndDialogue();
            return;
        }
        
    }
    
    void EndDialogue()
    {
        Debug.Log("End of convo");
    }
}
