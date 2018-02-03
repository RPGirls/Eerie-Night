
using UnityEngine;

namespace Assets.Scripts
{
    public class WinGame : MonoBehaviour
    {
        public string WinLevel;
        
        public static WinGame Instance = null;

        public void Awake()
        {
            if (Instance == null)//Check if instance already exists
                Instance = this;//if not, set instance to this
            else if (Instance != this)//If instance already exists and it's not this:
                Destroy(gameObject); //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
        }

        public void EndGame()
        {
            // Se tiver tudo coletado vai pra tela final

            // Se nao tiver coletado 
            //SceneManager.LoadScene (WinLevel);
            Debug.Log("Ganhou");
        }
    }
}
