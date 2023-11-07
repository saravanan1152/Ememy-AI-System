using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
public class Speech : MonoBehaviour
{
    KeywordRecognizer speechRecognizer;

    Dictionary<string,Action> wordTOAction;
    public string boxColor;
    private void Start()
    {
        wordTOAction = new Dictionary<string, Action>();

        wordTOAction.Add("green",Green);
        wordTOAction.Add("red",Red);
        wordTOAction.Add("rotate", Rotate);

        speechRecognizer = new KeywordRecognizer(wordTOAction.Keys.ToArray());
        speechRecognizer.OnPhraseRecognized += wordRecongnized;
        speechRecognizer.Start();
    }

  
    private void wordRecongnized(PhraseRecognizedEventArgs word)
    {
        Debug.Log(word.text);
        wordTOAction[word.text].Invoke();
        boxColor = word.text;
    }
    private void Rotate()
    {
        transform.Rotate(0, 0, 1);
    }

    private void Red()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

    private void Green()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }
}
