using System;
using System.Collections;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CarterGames.Assets.LeaderboardManager.Demo
{
    public class ExampleManager : MonoBehaviour
    {
        public StringBuilder sb = new StringBuilder();
        public LeaderboardDisplay leaderboard;
        string playerName;
        string playerAge;
        public GameObject leaderboardPanel;

        public Text scoreText;

        string folder;
        string filePath;

        private void Start()
        {
            folder = "C:\\Maggi\\";

            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            filePath = Path.Combine(folder, "export.csv");
            //filePath = folder;

            playerName = PlayerPrefs.GetString("name");
            playerAge = PlayerPrefs.GetString("age");
            //AddToBoard();
            record();
            ShowGameoverPopup();
        }
        //[SerializeField] private InputField boardID;
        //[SerializeField] private InputField playerName;
        //[SerializeField] private InputField playerScore;

        public void ShowGameoverPopup()
        {
            scoreText.text = "Your Score: " + PlayerPrefs.GetInt("score").ToString();
            StartCoroutine(WaitForPopup());
        }

        IEnumerator WaitForPopup()
        {
            yield return new WaitForSeconds(5f);
            AddToBoard();
        }

        public void AddToBoard()
        {
            string boardID = "Example";
            int playerScore = PlayerPrefs.GetInt("score");

            Debug.Log(playerName + "," + playerScore);

            LeaderboardManager.AddEntryToBoard(boardID, playerName, double.Parse(playerScore.ToString()));
            leaderboard.UpdateDisplay();
            leaderboardPanel.SetActive(true);
        }

        public void record()
        {
            sb.AppendLine("\n" + PlayerPrefs.GetString("name") + "  ;  " + PlayerPrefs.GetString("age") + "  ;  " + PlayerPrefs.GetString("phone") + "  ;  " + PlayerPrefs.GetString("email") + "  ;  " + PlayerPrefs.GetInt("score").ToString() );
            SaveToFile(sb.ToString());
        }
        public void SaveToFile(string content)
        {
            // Use the CSV generation from before
            //var content = ToCSV();

            // The target file path e.g.
            //var folder = Application.streamingAssetsPath;

            if (!File.Exists(filePath))
            {

                using (var writer = new StreamWriter(filePath, false))
                {
                    
                    writer.WriteLine(content);
                    writer.Close();
                }
            }
            else
            {
                using (var writer = new StreamWriter(filePath, true))
                {
                    Debug.LogError("file exist");
                    writer.BaseStream.Seek(0, SeekOrigin.End);
                    writer.WriteLine(content);
                    writer.Close();
                }
            }
        }

        public void OnBackButtonClicked()
        {
            SceneManager.LoadScene(0);
        }

        //public void RemoveFromBoard()
        //{
        //    if (playerName.text.Length <= 0 || playerScore.text.Length <= 0)
        //    {
        //        Debug.Log($"<color=D6BA64><b>Leaderboard Manager Example</b> | Either the name or score fields were blank, please ensure the fields are filled before using this option.</color>");
        //        return;
        //    }

        //    LeaderboardManager.DeleteEntryFromBoard(boardID.text, playerName.text, double.Parse(playerScore.text));
        //    playerName.text = string.Empty;
        //    playerScore.text = string.Empty;
        //}

        public void ClearBoard()
        {
            string boardID = "Example";
            LeaderboardManager.ClearLeaderboard(boardID);
        }
    }
}