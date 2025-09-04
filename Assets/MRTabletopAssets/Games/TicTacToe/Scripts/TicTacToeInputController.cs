using UnityEngine;
using UnityEngine.InputSystem;

namespace MRTTT.TicTacToe
{
    public class TicTacToeInputController : MonoBehaviour
    {
        [SerializeField] Camera m_Camera;
        [SerializeField] LayerMask m_BoardMask;
        [SerializeField] TicTacToeManager m_Manager;

        void Update()
        {
            if (Mouse.current == null)
                return;

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Vector2 screenPos = Mouse.current.position.ReadValue();
                Ray ray = m_Camera.ScreenPointToRay(screenPos);
                if (Physics.Raycast(ray, out RaycastHit hit, 100f, m_BoardMask))
                {
                    var cell = hit.collider.GetComponent<TicTacToeBoardCell>();
                    if (cell != null)
                    {
                        m_Manager.TryPlace(cell.Coordinates.x, cell.Coordinates.y);
                    }
                }
            }
        }
    }
}
