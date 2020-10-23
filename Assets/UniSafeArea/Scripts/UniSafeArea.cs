using UnityEngine;

namespace UniSafeArea
{
    [ExecuteInEditMode]
    public class UniSafeArea : MonoBehaviour
    {
        [SerializeField] private RectTransform _safeAreaTransform = null;
        private Resolution _resolutionCache;

        private void Update()
        {
            if (_safeAreaTransform == null || _resolutionCache.Equals(Screen.resolutions))
            {
                return;
            }

            UpdateSafeArea();
        }

        void UpdateSafeArea()
        {
            var area = SafeAreaProvider.GetSafeArea();
            var resolution = Screen.currentResolution;
            var rect = _safeAreaTransform;
            rect.anchorMax = new Vector2(area.xMax / Screen.width, area.yMax / Screen.height);
            rect.anchorMin = new Vector2(area.xMin / Screen.width, area.yMin / Screen.height);
            _resolutionCache = resolution;
        } 
    }
}
