using _SpaceInvaders.Scripts.StringValues;
using UnityEngine;

namespace _SpaceInvaders.Scripts.Inputing
{
    public class KeyboardInput : PlayerInput
    {
        protected override InputData GetInputData()
        {
            var inputData = new InputData()
            {
                Direction = new Vector2(Input.GetAxisRaw(InputName.Horizontal),
                                        Input.GetAxisRaw(InputName.Vertical)),
                Fire = Input.GetButtonDown(InputName.Space)
            };

            return inputData;
        }
    }
}