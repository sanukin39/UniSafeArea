using UnityEngine;

namespace UniSafeArea
{
    [ExecuteInEditMode, RequireComponent(typeof(RectTransform))]
    public class UniSafeArea : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private Resolution _resolutionCache;

        void OnEnable()
        {
            _rectTransform = GetComponent<RectTransform>();
            _rectTransform.sizeDelta = Vector2.zero;
        }

        private void Update()
        {
            if (_resolutionCache.Equals(Screen.resolutions))
            {
                return;
            }

            UpdateSafeArea();
        }

        void UpdateSafeArea()
        {
            var area = SafeAreaProvider.GetSafeArea();
            var resolution = Screen.currentResolution;
            _rectTransform.anchorMax = new Vector2(area.xMax / Screen.width, area.yMax / Screen.height);
            _rectTransform.anchorMin = new Vector2(area.xMin / Screen.width, area.yMin / Screen.height);
            _resolutionCache = resolution;
        }
    }
}
