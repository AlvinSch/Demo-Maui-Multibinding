using System.Globalization;

namespace MauiTestApp.Components
{
    [ContentProperty(nameof(Path))]
    public class InvalidationMultiBinding : IMarkupExtension<BindingBase>
    {
        /// <summary>
        /// Pfad zur Enum-Property (analog <see cref="Microsoft.Maui.Controls.Xaml"/>)
        /// </summary>
        public string Path { get; set; } = Binding.SelfPath;

        /// <summary>
        /// Binding-Mode (analog <see cref="Microsoft.Maui.Controls.Xaml"/>)
        /// </summary>
        public BindingMode Mode { get; set; } = BindingMode.Default;

        /// <summary>
        /// Binding-Source (analog <see cref="Microsoft.Maui.Controls.Xaml"/>)
        /// </summary>
        public object? Source { get; set; }

        public string? PathInvalidation { get; set; }

        public IValueConverter? Converter { get; set; }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);

        public BindingBase ProvideValue(IServiceProvider serviceProvider)
        {

            var result = new MultiBinding
            {
                Converter = new InvalidationMultiConverter(Converter),
                Bindings = new List<BindingBase>
                {
                    new Binding(path: PathInvalidation, BindingMode.OneWay, source: Source),
                    new Binding(path: Path, mode: Mode, source: Source)
                },
                Mode = Mode
            };

            return result;
        }
    }
}
