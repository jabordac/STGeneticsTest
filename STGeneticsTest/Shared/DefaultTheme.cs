namespace STGeneticsWeb.Shared;

using MudBlazor;

public class DefaultTheme : MudTheme
{
    public DefaultTheme()
    {
        Palette = new PaletteLight()
        {
            Background = "#F2F2F2",

            Primary = "#0A3A5A",
            PrimaryDarken = "#3D5687",
            PrimaryLighten = "#3D5687",
            PrimaryContrastText = "#FFFFFF",
            TextPrimary = "#3F3F3F",
            TextSecondary = "#9A9A9A",

            Secondary = "#1EA3DB",

            Tertiary = "#7CB749",
            TertiaryDarken = "#99D961",
            TertiaryLighten = "#99D961",

            Info = "#1EA3DB",
            Error = "#EF355C",
            Warning = "#D68500",
            Success = "#7CB749",

            ActionDisabledBackground = "#7F7F7F",
            TableHover = "#F6F6F6",

            DrawerBackground = "#C1C1C6",
            DrawerIcon = "#FFFFFF",
            DrawerText = "#3F3F3F",

            AppbarBackground = "#0A3A5A",
        };

        LayoutProperties = new LayoutProperties()
        {
            DefaultBorderRadius = "6px",
            AppbarHeight = "42px",
            DrawerMiniWidthLeft = "56px",
            DrawerWidthLeft = "240px",
            DrawerMiniWidthRight = "18px",
            DrawerWidthRight = "520px",
        };

        Typography = new Typography()
        {
            Button = new Button()
            {
                TextTransform = "none"
            },
            Overline = new Overline()
            {
                TextTransform = "none"
            }
        };

        Shadows = new Shadow();

        ZIndex = new ZIndex();
    }

}