namespace _SpaceInvaders.Scripts.Inputting
{
    public class HandheldInput : PlayerInput
    {
        private readonly JoystickHandler _joystickHandler;
        private readonly PressingFireButton _pressingFireButton;

        public HandheldInput(JoystickHandler joystickHandler,
                             PressingFireButton pressingFireButton)
        {
            _joystickHandler = joystickHandler;
            _pressingFireButton = pressingFireButton;
        }

        protected override InputData GetInputData()
        {
            var inputData = new InputData()
            {
                Direction = _joystickHandler.GetInputVector,
                Fire = _pressingFireButton.IsFire
            };
            
            return inputData;
        }
    }
}