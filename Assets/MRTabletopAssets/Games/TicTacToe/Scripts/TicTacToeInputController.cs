using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

namespace MRTTT.TicTacToe
{
    public class TicTacToeInputController : MonoBehaviour
    {
        [SerializeField] XRRayInteractor m_Interactor;
        [SerializeField] InputActionProperty m_Select;
        [SerializeField] TicTacToeManager m_Manager;

        void Update()
        {
            if (m_Interactor == null || m_Select.action == null)
                return;

            if (m_Select.action.WasPerformedThisFrame())
            {
                if (m_Interactor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
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
