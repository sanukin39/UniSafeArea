using UnityEngine;

namespace UniSafeArea
{
    public static class SafeAreaProvider
    {
        public static Rect GetSafeArea()
        {
            var safeArea = Screen.safeArea;
#if !UNITY_EDITOR
            return safeArea;
#endif
            var width = Screen.width;
            var height = Screen.height;
            var isPortrait = height > width;

            var devices = new[]
            {
                // iPhone X/XS/11Pro
                new DeviceSafeAreaMargin(1125, 2436, new ScreenMargin(132, 102, 0, 0),
                    new ScreenMargin(0, 63, 132, 132)),
                // iPhone XR/11
                new DeviceSafeAreaMargin(828, 1792, new ScreenMargin(88, 68, 0, 0),
                    new ScreenMargin(0, 42, 88, 88)),
                // iPhone XSMax/11ProMax
                new DeviceSafeAreaMargin(1242, 2688, new ScreenMargin(132, 102, 0, 0),
                    new ScreenMargin(0, 63, 132, 132)),
                /* iPhone 12mini has same resolution at iPhone X but has not same safe area
                new DeviceSafeAreaMargin(1125, 2436, new ScreenMargin(150, 102, 0, 0),
                    new ScreenMargin(0, 63, 150, 150)),
                */
                // iPhone 12/12Pro
                new DeviceSafeAreaMargin(1170, 2532, new ScreenMargin(141, 102, 0, 0),
                    new ScreenMargin(0, 63, 141, 141)),
                // iPhone 12ProMax
                new DeviceSafeAreaMargin(1284, 2778, new ScreenMargin(141, 102, 0, 0),
                    new ScreenMargin(0, 63, 141, 141)),
                // iPad Air4th
                new DeviceSafeAreaMargin(1640, 2360, new ScreenMargin(0, 40, 0, 0),
                    new ScreenMargin(0, 40, 0, 0)),
                // iPad Pro11inch2nd
                new DeviceSafeAreaMargin(1668, 2388, new ScreenMargin(0, 40, 0, 0),
                    new ScreenMargin(0, 40, 0, 0)),
                // iPad Pro12.9inch4th
                new DeviceSafeAreaMargin(2048, 2732, new ScreenMargin(0, 40, 0, 0),
                    new ScreenMargin(0, 40, 0, 0))
            };

            foreach (var device in devices)
            {
                if (!HasSaveResolution(device, width, height))
                {
                    continue;
                }

                return CalcSafeArea(device, isPortrait);
            }

            return safeArea;
        }

        static bool HasSaveResolution(DeviceSafeAreaMargin device, int width, int height)
        {
            return device.ScreenWidth == width && device.ScreenHeight == height ||
                   device.ScreenHeight == width && device.ScreenWidth == height;
        }

        static Rect CalcSafeArea(DeviceSafeAreaMargin device, bool isPortrait)
        {
            var margin = isPortrait ? device.PortraitMargin : device.LandscapeMargin;
            var width = isPortrait ? device.ScreenWidth : device.ScreenHeight;
            var height = isPortrait ? device.ScreenHeight : device.ScreenWidth;
            return Rect.MinMaxRect(margin.Left, margin.Bottom, width - margin.Right, height - margin.Top);
        }

        readonly struct DeviceSafeAreaMargin
        {
            public readonly int ScreenWidth;
            public readonly int ScreenHeight;
            public readonly ScreenMargin PortraitMargin;
            public readonly ScreenMargin LandscapeMargin;

            public DeviceSafeAreaMargin(int screenWidth, int screenHeight, ScreenMargin portraitMargin, ScreenMargin landscapeMargin)
            {
                ScreenWidth = screenWidth;
                ScreenHeight = screenHeight;
                PortraitMargin = portraitMargin;
                LandscapeMargin = landscapeMargin;
            }
        }

        readonly struct ScreenMargin
        {
            public readonly int Top;
            public readonly int Bottom;
            public readonly int Left;
            public readonly int Right;

            public ScreenMargin(int top, int bottom, int left, int right)
            {
                Top = top;
                Bottom = bottom;
                Left = left;
                Right = right;
            }
        }
    }
}
