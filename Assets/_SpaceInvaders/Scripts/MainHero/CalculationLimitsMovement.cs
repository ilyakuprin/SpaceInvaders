using _SpaceInvaders.Scripts.ScriptableObj;
using UnityEngine;
using Zenject;

namespace _SpaceInvaders.Scripts.MainHero
{
    public class CalculationLimitsMovement : IInitializable
    {
        private static readonly Vector3 LowerLeftCorner = new (0, 0, 0);
        private static readonly Vector3 LowerRightCorner = new (1, 0, 0);

        private const float Half = 0.5f; 
        
        private readonly Camera _camera;
        private readonly SpriteRenderer _spriteRenderer;
        private readonly float _finishLineHeightInMainHero;
        
        private float _bottomBorder;
        private float _leftBorder;
        private float _rightBorder;
        private float _upperBorder;

        public CalculationLimitsMovement(Camera camera,
                                         MainHeroView mainHeroView,
                                         MainHeroConfig mainHeroConfig)
        {
            _camera = camera;
            _spriteRenderer = mainHeroView.SpriteRenderer;
            _finishLineHeightInMainHero = mainHeroConfig.FinishLineHeightInMainHero;
        }

        public void Initialize()
            => Calculate();

        public Vector2 GetClamp(Vector2 targetPosition)
        {
            targetPosition.x = Mathf.Clamp(targetPosition.x, _leftBorder, _rightBorder);
            targetPosition.y = Mathf.Clamp(targetPosition.y, _bottomBorder, _upperBorder);
            return targetPosition;
        }

        private void Calculate()
        {
            var bounds = _spriteRenderer.bounds;
            var sizeY = bounds.size.y;
            var halfPlayerSizeX = bounds.size.x * Half;
            var halfPlayerSizeY = sizeY * Half;

            var leftBottomCorner = _camera.ViewportToWorldPoint(LowerLeftCorner);
            
            _leftBorder = leftBottomCorner.x + halfPlayerSizeX;
            _rightBorder = _camera.ViewportToWorldPoint(LowerRightCorner).x - halfPlayerSizeX;
            _bottomBorder = leftBottomCorner.y + halfPlayerSizeY;
            _upperBorder = leftBottomCorner.y + 
                          sizeY * _finishLineHeightInMainHero -
                          halfPlayerSizeY;
        }
    }
}