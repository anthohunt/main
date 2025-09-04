using UnityEngine;

namespace MRTTT.TicTacToe
{
    public class TicTacToeBoardCell : MonoBehaviour
    {
        public Vector2Int Coordinates { get; private set; }
        public TicTacToePiece OccupyingPiece { get; private set; }

        public void Initialize(int x, int y)
        {
            Coordinates = new Vector2Int(x, y);
        }

        public bool IsEmpty => OccupyingPiece == null;

        public void PlacePiece(TicTacToePiece piece)
        {
            OccupyingPiece = piece;
        }

        public void Clear()
        {
            OccupyingPiece = null;
        }
    }
}
