using System.Collections;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechToText : MonoBehaviour
{
    private DictationRecognizer dictationRecognizer;

    void Start()
    {
        dictationRecognizer = new DictationRecognizer();

        // Subscribe to the DictationRecognizer events
        dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;
        dictationRecognizer.DictationHypothesis += DictationRecognizer_DictationHypothesis;
        dictationRecognizer.DictationComplete += DictationRecognizer_DictationComplete;
        dictationRecognizer.DictationError += DictationRecognizer_DictationError;

        // Start the speech recognition
        dictationRecognizer.Start();
    }

    private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
    {
        // This method is called when a recognized word or phrase is detected
        Debug.Log("Recognized: " + text);
    }

    private void DictationRecognizer_DictationHypothesis(string text)
    {
        // This method is called while the recognizer is still processing speech
        // You can use it for real-time feedback, if needed
        Debug.Log("Hypothesis: " + text);
    }

    private void DictationRecognizer_DictationComplete(DictationCompletionCause cause)
    {
        // This method is called when the recognition is completed
        if (cause != DictationCompletionCause.Complete)
        {
            // Handle recognition errors or incomplete recognition here
            Debug.LogError("Dictation completed with an error or was canceled.");
        }
    }

    private void DictationRecognizer_DictationError(string error, int hresult)
    {
        // This method is called when there's an error with the recognition
        Debug.LogError("Dictation error: " + error);
    }

    private void OnDestroy()
    {
        // Clean up the recognizer when the script is destroyed
        if (dictationRecognizer != null)
        {
            dictationRecognizer.Dispose();
        }
    }
}
