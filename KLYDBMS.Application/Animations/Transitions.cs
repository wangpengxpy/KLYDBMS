using Avalonia.Animation;
using System;

namespace KLYDBMS.Application.Animations
{
    public static class Transitions
    {
        public static IPageTransition Fade => new CrossFade(TimeSpan.FromMilliseconds(200));

        public static IPageTransition Slide => new PageSlide(TimeSpan.FromMilliseconds(200));
    }
}
