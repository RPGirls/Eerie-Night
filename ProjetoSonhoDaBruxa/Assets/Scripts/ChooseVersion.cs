using UnityEngine;

namespace Assets.Scripts
{
    public class ChooseVersion : MonoBehaviour
    {

        public GameObject[] ListOfPossibleObjects;
        
        public void Start () {
            var random = Random.Range(0, ListOfPossibleObjects.Length);
            for (var i = 0; i < ListOfPossibleObjects.Length; i++)
                ListOfPossibleObjects[i].SetActive(i == random);
        }
    }
}
