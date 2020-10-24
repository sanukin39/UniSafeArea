using System;
using UnityEngine;
using UnityEngine.UI;

namespace UniSafeArea.Sample
{
    [RequireComponent(typeof(Text))]
    public class SafeAreaText : MonoBehaviour
    {
        private Text _text;
        
        void Awake()
        {
            _text = GetComponent<Text>();
        }

        void Update()
        {
            ApplySafeAreaData(_text);
        }

        void ApplySafeAreaData(Text text)
        {
            var safeArea = SafeAreaProvider.GetSafeArea();
            text.text = $"Screen Size {Screen.width} : {Screen.height} {Environment.NewLine} Safe Area {safeArea} {Environment.NewLine}"
                        + $"Margin Left {safeArea.x} : Bottom {safeArea.y} : Right {Screen.width - safeArea.width - safeArea.x} : Top {Screen.height - safeArea.height - safeArea.y}";
        }
    }
}
