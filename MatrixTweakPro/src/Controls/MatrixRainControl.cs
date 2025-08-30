using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace MatrixTweakPro.Controls
{
    /// <summary>
    /// Simple Matrix rain background.
    /// </summary>
    public class MatrixRainControl : Canvas
    {
        private readonly List<Glyph> _glyphs = new();
        private readonly DispatcherTimer _timer;
        private readonly Random _random = new();
        private readonly char[] _charset = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        public MatrixRainControl()
        {
            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(50) };
            _timer.Tick += (s, e) => InvalidateVisual();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            CreateGlyphs();
            _timer.Start();
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
        }

        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);
            if (_glyphs.Count == 0) return;

            foreach (var glyph in _glyphs)
            {
                var ft = new FormattedText(
                    glyph.Character.ToString(),
                    System.Globalization.CultureInfo.InvariantCulture,
                    FlowDirection.LeftToRight,
                    new Typeface("Consolas"),
                    16,
                    Brushes.Lime,
                    VisualTreeHelper.GetDpi(this).PixelsPerDip);
                dc.DrawText(ft, new Point(glyph.X, glyph.Y));
                glyph.Y += glyph.Speed;
                if (glyph.Y > ActualHeight)
                {
                    glyph.Y = -_random.Next(20, 100);
                    glyph.Character = RandomChar();
                }
            }
        }

        private void CreateGlyphs()
        {
            _glyphs.Clear();
            for (double x = 0; x < ActualWidth; x += 20)
            {
                _glyphs.Add(new Glyph
                {
                    X = x,
                    Y = _random.NextDouble() * ActualHeight,
                    Character = RandomChar(),
                    Speed = 5 + _random.NextDouble() * 10
                });
            }
        }

        private char RandomChar() => _charset[_random.Next(_charset.Length)];

        private class Glyph
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Speed { get; set; }
            public char Character { get; set; }
        }
    }
}
