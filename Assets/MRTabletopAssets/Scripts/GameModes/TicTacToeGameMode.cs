using UnityEngine;

namespace MRTTT
{
    public class TicTacToeGameMode : MonoBehaviour, IGameMode
    {
        public int gameModeID => m_GameModeID;

        [SerializeField] int m_GameModeID = 4;
        [SerializeField] GameObject m_RootObject;
        [SerializeField] MRTTT.TicTacToe.TicTacToeManager m_Manager;
        [SerializeField] MRTTT.TicTacToe.TicTacToeAI m_AI;

        public void OnGameModeStart()
        {
            if (m_Manager != null)
                m_Manager.ResetBoard();
        }

        public void OnGameModeEnd()
        {
        }

        public void HideGameMode()
        {
            if (m_RootObject != null)
                m_RootObject.SetActive(false);
        }

        public void ShowGameMode()
        {
            if (m_RootObject != null)
                m_RootObject.SetActive(true);
        }
    }
}
