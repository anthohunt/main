using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MRTTT.TicTacToe
{
    public class TicTacToeUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI m_StatusText;
        [SerializeField] Button m_RestartButton;

        TicTacToeManager m_Manager;

        void Awake()
        {
            m_Manager = FindObjectOfType<TicTacToeManager>();
            if (m_Manager != null)
            {
                m_Manager.TurnChanged += OnTurnChanged;
                m_Manager.GameOver += OnGameOver;
            }
            if (m_RestartButton != null)
                m_RestartButton.onClick.AddListener(OnRestart);
        }

        void OnDestroy()
        {
            if (m_Manager != null)
            {
                m_Manager.TurnChanged -= OnTurnChanged;
                m_Manager.GameOver -= OnGameOver;
            }
        }

        void OnRestart()
        {
            m_Manager?.ResetBoard();
        }

        void OnTurnChanged(TicTacToePiece.PieceType player)
        {
            SetStatus($"{player} Turn");
        }

        void OnGameOver(TicTacToePiece.PieceType winner)
        {
            if (winner == TicTacToePiece.PieceType.None)
                SetStatus("Draw!");
            else
                SetStatus($"{winner} Wins!");
        }

        void SetStatus(string text)
        {
            if (m_StatusText != null)
                m_StatusText.text = text;
        }
    }
}
