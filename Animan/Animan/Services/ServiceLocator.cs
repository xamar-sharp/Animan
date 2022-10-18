using System;
using System.Collections.Generic;
using System.Text;
using Animan.Constants;
using Animan.Dependencies;
using Animan.Models;
using Xamarin.Forms;
namespace Animan.Services
{
    public sealed class ServiceLocator
    {
        public IAssetProvider AssetProvider { get; }
        public IValueFormatter<Color> ColorMapper { get; }
        public IValueFormatter<Brush> LinearGradientMapper { get; }
        public IValueFormatter<double> DoubleFormatter { get; }
        public IValueFormatter<bool> BooleanFormatter { get; }
        public IValueFormatter<FontAttributes> FontAttributesMapper { get; }
        public IValueFormatter<TextType> TextTypeMapper { get; }
        public IValueFormatter<TextAlignment> TextAlignmentFormatter { get; }
        public IValueFormatter<LayoutOptions> LayoutOptionsFormatter { get; }
        public IValueFormatter<TextTransform> TextTransformFormatter { get; }
        public IValueFormatter<TextDecorations> TextDecorationsFormatter { get; }
        public IValueFormatter<StackOrientation> StackOrientationFormatter { get; }
        public IValueFormatter<NamedSize> NamedSizeMapper { get; }
        public IValueFormatter<Aspect> AspectMapper { get; }
        public IValueFormatter<Point> PositionMapper { get; set; }
        public IValueFormatter<ImageSource> ImageFormatter { get; set; }
        public IPropertyMapper<StackLayout> EnvironmentPropertyMapper { get; }
        public IPropertyMapper<Image> ImagePropertyMapper { get; }
        public IPropertyMapper<Label> LabelPropertyMapper { get; }
        public IElementRecognizer ElementRecognizer { get; }
        public HelpProvider HelpProvider { get; }
        public ServiceLocator()
        {
            AssetProvider = DependencyService.Get<IAssetProvider>();
            ColorMapper = new ColorMapper();
            LinearGradientMapper = new LinearGradientMapper(ColorMapper);
            DoubleFormatter = new DoubleMapper();
            BooleanFormatter = new BooleanMapper();
            FontAttributesMapper = new EnumMapper<FontAttributes>();
            TextTypeMapper = new EnumMapper<TextType>();
            TextAlignmentFormatter = new EnumMapper<TextAlignment>();
            TextTransformFormatter = new EnumMapper<TextTransform>();
            TextDecorationsFormatter = new EnumMapper<TextDecorations>();
            StackOrientationFormatter = new EnumMapper<StackOrientation>();
            NamedSizeMapper = new EnumMapper<NamedSize>();
            AspectMapper = new EnumMapper<Aspect>();
            PositionMapper = new PositionMapper();
            LayoutOptionsFormatter = new LayoutOptionsMapper();
            ImageFormatter = new ImageSourceMapper();
            ImagePropertyMapper = new ImagePropertyMapper();
            EnvironmentPropertyMapper = new EnvironmentPropertyMapper();
            LabelPropertyMapper = new LabelPropertyMapper();
            ElementRecognizer = new SimpleElementRecognizer();
            HelpProvider = new HelpProvider(new HelpModel[]
            {
                new HelpModel(){Description = Resource.FormatDescription,Command=Resource.FormatName,Type=HelpType.Guide,Properties=new string[]{">",",",":","-"} }
            });
            HelpProvider.Init();
        }
    }
}
