using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    private bool isPaused = false;

    public Text questionText;  // Text component to display the question
    public Text explanationText;  // Text component to display explanation when paused
    public Image backgroundImage; // Background image to display when game is paused
    public ScriptableScript quizData; // Reference to ScriptableObject containing quizzes
    private int currentQuestionIndex = 0;  // Starting at question 0

    void Start()
    {
        if (questionText != null)
        {
            questionText.gameObject.SetActive(true);  // Ensure question text is visible initially
        }

        if (explanationText != null)
        {
            explanationText.gameObject.SetActive(false);  // Hide explanation text initially
        }

        if (backgroundImage != null)
        {
            backgroundImage.gameObject.SetActive(false);  // Initially hide the background image
        }

        // Ensure the first question is set at the start
        SetCurrentQuestionIndex(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            if (isPaused)
            {
                UnpauseGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        if (quizData != null && quizData.quizList.Count > currentQuestionIndex)
        {
            //string explanation = quizData.quizList[currentQuestionIndex].explanation;

            //if (string.IsNullOrEmpty(explanation))
            //{
            //    Debug.LogWarning("Cannot Pause - No Explanation for Question: " + currentQuestionIndex);
            //    return;
            //}

            // ✅ Pause the game, display explanation, and show background image
            Time.timeScale = 0f;
            AudioListener.pause = true;
            isPaused = true;

            // Hide question text
            if (questionText != null)
            {
                questionText.gameObject.SetActive(false);
            }

            // Show explanation text only when paused
            //explanationText.text = explanation;  // Set the explanation text
            explanationText.gameObject.SetActive(true);  // Show the explanation text

            // Show the background image only when paused
            if (backgroundImage != null)
            {
                backgroundImage.gameObject.SetActive(true);  // Show the background image
            }

            Debug.Log("Game Paused - Explanation Displayed for Question: " + currentQuestionIndex);
        }
        else
        {
            Debug.LogWarning("Cannot Pause - Invalid Quiz Data or Index Out of Range");
        }
    }

    void UnpauseGame()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        isPaused = false;

        // Show question text again when unpaused
        if (questionText != null)
        {
            questionText.gameObject.SetActive(true);
        }

        // Hide explanation text when unpaused
        if (explanationText != null)
        {
            explanationText.gameObject.SetActive(false);
        }

        // Hide the background image when unpaused
        if (backgroundImage != null)
        {
            backgroundImage.gameObject.SetActive(false);
        }
    }

    public void SetCurrentQuestionIndex(int index)
    {
        if (index >= 0 && quizData != null && index < quizData.quizList.Count)
        {
            currentQuestionIndex = index;
            Debug.Log("Current Question Index Updated: " + currentQuestionIndex);

            // Update the question text
            if (questionText != null && quizData.quizList.Count > currentQuestionIndex)
            {
                questionText.text = quizData.quizList[currentQuestionIndex].question;
            }

            // Call a separate method to load the current question (display it, show options, etc.)
            DisplayCurrentQuestion();
        }
        else
        {
            Debug.LogWarning("Invalid Question Index: " + index);
        }
    }

    public void MoveToNextQuestion()
    {
        // Move to the next question if there are more questions available
        if (currentQuestionIndex < quizData.quizList.Count - 1)
        {
            SetCurrentQuestionIndex(currentQuestionIndex + 1);
        }
        else
        {
            Debug.Log("End of Quiz");
            // Handle quiz end logic here (e.g., show a final score or message)
        }
    }

    private void DisplayCurrentQuestion()
    {
        // Display the current question (if not already updated in SetCurrentQuestionIndex)
        if (quizData != null && quizData.quizList.Count > currentQuestionIndex)
        {
            var currentQuestion = quizData.quizList[currentQuestionIndex];
            // You can display additional info about the question here if needed
            Debug.Log("Displaying Question: " + currentQuestion.question);
        }
    }
}
