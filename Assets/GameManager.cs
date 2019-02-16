using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public QuestionDefinition[] questions;
    public Text questionText;
    public GameObject restartButton;
    private int points = 0;
    private int questionIndex = 0;

    private void Start() {
        restartButton.SetActive(false);
        LoadQuestion();
    }

    private void LoadQuestion() {
        if (questionIndex < questions.Length) {
            questionText.text = questions[questionIndex].question;
        }
        else {
            EndQuiz();
        }
        Debug.Log(points);
    }

    private void EndQuiz() {
        restartButton.SetActive(true);
        questionText.text = "Koniec quizu. Poprawne odpowiedzi: " + points + "/" + questionIndex;
    }

    public void TrueAnswer() {
        if (questionIndex < questions.Length) {
            if (questions[questionIndex].trueOrFalse == true) {
                Debug.Log("Point added");
                points++;
            }
            else {
                Debug.Log("Wrong answer");
            }
            Debug.Log("Next question loaded");
            questionIndex++;
            LoadQuestion();
        }
    }

    public void FalseAnswer() {
        if (questionIndex < questions.Length) {
            if (questions[questionIndex].trueOrFalse == false) {
                Debug.Log("Point added");
                points++;
            }
            else {
                Debug.Log("Wrong answer");
            }
            Debug.Log("Next question loaded");
            questionIndex++;
            LoadQuestion();
        }
    }

    public void RestartTheGame() {
        questionIndex = 0;
        points = 0;
        restartButton.SetActive(false);
        LoadQuestion();
    }
}
