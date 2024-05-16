using TMPro;
using UnityEngine;
using Zenject;

namespace Code
{
    public class OutputFruitCound : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private FruitController _fruitController;
        private int _maxFruit;

        [Inject]
        private void Construct(FruitController fruitController)
        {
            _fruitController = fruitController;
            _fruitController.OnCountFruits += OutputText;
        }

        private void Start()
        {
            _maxFruit = _fruitController._countFruit;
            OutputText(_maxFruit);
        }

        private void OnDestroy()
        {
            _fruitController.OnCountFruits -= OutputText;
        }

        private void OutputText(int count)
        {
            _text.text = $"{count}/{_maxFruit}";
        }
    }
}