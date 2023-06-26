namespace STGeneticsWeb.Shared;

public partial class MainLayout
{
    bool open = false;

    void ToggleDrawer()
    {
        open = !open;
    }
}