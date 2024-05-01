using UnityEngine.SceneManagement;

namespace _SpaceInvaders.Scripts.Restart
{
    public class RestartingGame
    {
        public static void Restart()
            => SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}