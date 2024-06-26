using Zenject;

namespace _SpaceInvaders.Scripts.Inputting
{
    public class ActivatingCanvasInput : IInitializable
    {
        private readonly CanvasInputView _canvasInputView;

        public ActivatingCanvasInput(CanvasInputView canvasInputView)
        {
            _canvasInputView = canvasInputView;
        }

        public void Initialize()
        {
            _canvasInputView.CanvasInput.gameObject.SetActive(true);
        }
    }
}