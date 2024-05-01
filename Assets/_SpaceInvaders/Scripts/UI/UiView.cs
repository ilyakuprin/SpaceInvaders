using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _SpaceInvaders.Scripts.UI
{
    public class UiView : MonoBehaviour
    {
        [field: SerializeField] public TextMeshProUGUI Score { get; private set; }
        [field: SerializeField] public Button Pause { get; private set; }
        [field: SerializeField] public Canvas PauseCanvas { get; private set; }
        
        [field: SerializeField] public Button Unpause { get; private set; }
        [field: SerializeField] public Button Restart { get; private set; }
    }
}