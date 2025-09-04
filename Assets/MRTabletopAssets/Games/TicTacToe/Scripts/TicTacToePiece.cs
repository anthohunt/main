using UnityEngine;

namespace MRTTT.TicTacToe
{
    public class TicTacToePiece : MonoBehaviour
    {
        public enum PieceType
        {
            None,
            X,
            O
        }

        [SerializeField]
        PieceType m_Type = PieceType.None;

        public PieceType Type => m_Type;

        public void SetType(PieceType type)
        {
            m_Type = type;
            // Visual updates can be added here
        }
    }
}
