using UnityEngine;

namespace UniSafeArea
{
    [ExecuteInEditMode, RequireComponent(typeof(RectTransform))]
    public class UniSafeArea : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private Vector2 _resolutionCache;

        void OnEnable()
        {
            _rectTransform = GetComponent<RectTransform>();
            _rectTransform.sizeDelta = Vector2.zero;
        }

        private void Update()
        {
            var resolution = new Vector2(Screen.width, Screen.height);
            if (_resolutionCache.Equals(resolution))
            {
                return;
            }

            UpdateSafeArea(resolution);
        }

        void UpdateSafeArea(Vector2 resolution)
        {
            var area = SafeAreaProvider.GetSafeArea();
            _rectTransform.anchorMax = new Vector2(area.xMax / resolution.x, area.yMax / resolution.y);
            _rectTransform.anchorMin = new Vector2(area.xMin / resolution.x, area.yMin / resolution.y);
            _resolutionCache = resolution;
        }
    }
}
