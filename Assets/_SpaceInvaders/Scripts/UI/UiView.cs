using TMPro;
using UnityEngine;

namespace _SpaceInvaders.Scripts.UI
{
    public class UiView : MonoBehaviour
    {
        [field: SerializeField] public TextMeshProUGUI Score { get; private set; }
    }
}