using UnityEngine;

namespace MRTTT.TicTacToe
{
    public class TicTacToeAI : MonoBehaviour
    {
        [SerializeField] TicTacToeManager m_Manager;

        // Simple AI that places in first available cell
        public void MakeMove()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (m_Manager.TryPlace(x, y))
                        return;
                }
            }
        }
    }
}
