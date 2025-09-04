using UnityEngine;

namespace MRTTT.TicTacToe
{
    public class TicTacToeManager : MonoBehaviour
    {
        const int k_BoardSize = 3;

        TicTacToePiece.PieceType[,] m_Board = new TicTacToePiece.PieceType[k_BoardSize, k_BoardSize];

        [SerializeField] TicTacToePiece m_XPrefab;
        [SerializeField] TicTacToePiece m_OPrefab;
        [SerializeField] Transform m_BoardRoot;

        TicTacToePiece.PieceType m_CurrentPlayer = TicTacToePiece.PieceType.X;

        public void ResetBoard()
        {
            for (int x = 0; x < k_BoardSize; x++)
                for (int y = 0; y < k_BoardSize; y++)
                    m_Board[x, y] = TicTacToePiece.PieceType.None;

            m_CurrentPlayer = TicTacToePiece.PieceType.X;
        }

        public bool TryPlace(int x, int y)
        {
            if (m_Board[x, y] != TicTacToePiece.PieceType.None)
                return false;

            m_Board[x, y] = m_CurrentPlayer;
            // Instantiate piece prefab if assigned
            var prefab = m_CurrentPlayer == TicTacToePiece.PieceType.X ? m_XPrefab : m_OPrefab;
            if (prefab != null && m_BoardRoot != null)
            {
                var piece = Instantiate(prefab, m_BoardRoot);
                piece.SetType(m_CurrentPlayer);
                piece.transform.localPosition = new Vector3(x, 0, y);
            }

            m_CurrentPlayer = m_CurrentPlayer == TicTacToePiece.PieceType.X ? TicTacToePiece.PieceType.O : TicTacToePiece.PieceType.X;
            return true;
        }

        public TicTacToePiece.PieceType CheckWinner()
        {
            for (int i = 0; i < k_BoardSize; i++)
            {
                if (m_Board[i,0] != TicTacToePiece.PieceType.None &&
                    m_Board[i,0] == m_Board[i,1] &&
                    m_Board[i,1] == m_Board[i,2])
                    return m_Board[i,0];

                if (m_Board[0,i] != TicTacToePiece.PieceType.None &&
                    m_Board[0,i] == m_Board[1,i] &&
                    m_Board[1,i] == m_Board[2,i])
                    return m_Board[0,i];
            }

            if (m_Board[0,0] != TicTacToePiece.PieceType.None &&
                m_Board[0,0] == m_Board[1,1] &&
                m_Board[1,1] == m_Board[2,2])
                return m_Board[0,0];

            if (m_Board[2,0] != TicTacToePiece.PieceType.None &&
                m_Board[2,0] == m_Board[1,1] &&
                m_Board[1,1] == m_Board[0,2])
                return m_Board[2,0];

            return TicTacToePiece.PieceType.None;
        }
    }
}
