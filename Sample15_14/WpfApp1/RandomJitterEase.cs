using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace WpfApp1
{
    public class RandomJitterEase : EasingFunctionBase
    {
        // Генератор случайных чисел
        private Random rand = new Random();

        protected override double EaseInCore(double normalizedTime)
        {
            if (normalizedTime == 1) return 1;
            return Math.Abs(normalizedTime - (double)rand.Next(0, 10) / (2010 - Jitter));
        }

        public int Jitter
        {
            get { return (int)GetValue(JitterProperty); }
            set { SetValue(JitterProperty, value); }
        }

        public static readonly DependencyProperty JitterProperty =
            DependencyProperty.Register("Jitter", typeof(int), typeof(RandomJitterEase),
            new UIPropertyMetadata(1000), new ValidateValueCallback(ValidateJitter));

        private static bool ValidateJitter(object value)
        {
            int jitterValue = (int)value;
            return ((jitterValue <= 2000) && (jitterValue >= 0));
        }

        protected override Freezable CreateInstanceCore()
        {
            return new RandomJitterEase();
        }
    }
}
