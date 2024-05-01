using UnityEngine;
using UnityEngine.UI;

namespace _SpaceInvaders.Scripts.Inputting
{
    public class CanvasInputView : MonoBehaviour
    {
        [field: SerializeField] public Canvas CanvasInput { get; private set; }
        [field: SerializeField] public Button Fire { get; private set; }
    }
}