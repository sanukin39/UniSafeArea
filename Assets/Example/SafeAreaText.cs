using System.Text;
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
            var strBuilder = new StringBuilder();
            strBuilder.AppendLine("Screen Size");
            strBuilder.AppendLine($"{Screen.width} : {Screen.height}");
            strBuilder.AppendLine();
            strBuilder.AppendLine("Safe Area");
            strBuilder.AppendLine(safeArea.ToString());
            strBuilder.AppendLine();
            strBuilder.AppendLine("Margin");
            strBuilder.AppendLine(
                $"Left {safeArea.x} : Bottom {safeArea.y} : Right {Screen.width - safeArea.width - safeArea.x} : Top {Screen.height - safeArea.height - safeArea.y}");
            text.text = strBuilder.ToString();
        }
    }
}
