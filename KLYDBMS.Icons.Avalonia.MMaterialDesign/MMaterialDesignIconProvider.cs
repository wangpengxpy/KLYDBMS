﻿using Projektanker.Icons.Avalonia;
using Projektanker.Icons.Avalonia.Models;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace KLYDBMS.Icons.Avalonia.MMaterialDesign
{
    /// <summary>
    /// Implements the <see cref="IIconProvider"/> interface to provide Material Design icons.
    /// </summary>
    public class MMaterialDesignIconProvider : IIconProvider
    {
        private const string _mdiProviderPrefix = "kly";

        private static readonly string _resourceNameTemplate
            = $"{typeof(MMaterialDesignIconProvider).Assembly.GetName().Name}.Assets.{{0}}.svg";

        private static readonly Regex _viewBoxRegex = new("viewBox=\"([0-9 -]+)\"");
        private static readonly Regex _pathRegex = new("<path d=\"(.+)\"");
        private readonly Dictionary<string, IconModel> _icons = new();

        public string Prefix => _mdiProviderPrefix;

        /// <inheritdoc/>
        public IconModel GetIcon(string value)
        {
            if (_icons.TryGetValue(value, out var icon))
            {
                return icon;
            }

            icon = GetIconFromResource(value);
            return _icons[value] = icon;
        }

        private static IconModel GetIconFromResource(string value)
        {
            using Stream stream = GetIconResourceStream(value);
            using TextReader textReader = new StreamReader(stream);
            var svg = textReader.ReadToEnd();
            var viewBoxMath = _viewBoxRegex.Match(svg);
            var viewBox = viewBoxMath.Groups[1].Value;
            var pathMatch = _pathRegex.Match(svg);
            var path = pathMatch.Groups[1].Value;
            return new IconModel(
                ViewBoxModel.Parse(viewBox),
                new PathModel(path));
        }

        private static Stream GetIconResourceStream(string value)
        {
            return TryGetIconResourceStream(value, out var stream)
                ? stream
                : throw new KeyNotFoundException($"MMaterial Design Icon \"{value}\" not found!");
        }

        private static bool TryGetIconResourceStream(string value, out Stream stream)
        {
            stream = default;

            if (value.Length <= _mdiProviderPrefix.Length + 1)
            {
                return false;
            }

            var withoutPrefix = value.Substring(_mdiProviderPrefix.Length + 1);
            var resourceName = string.Format(_resourceNameTemplate, withoutPrefix);
            stream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream(resourceName);

            return stream != default;
        }
    }
}