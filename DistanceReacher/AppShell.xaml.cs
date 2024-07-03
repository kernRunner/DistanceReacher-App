namespace DistanceReacher;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        this.Navigating += OnShellNavigating;
    }

    private void OnShellNavigating(object sender, ShellNavigatingEventArgs e)
    {
        // Check if the user is navigating to a different tab
        if (e.Source == ShellNavigationSource.ShellSectionChanged)
        {
            // If navigating to a different tab, pop to the root page
            var currentNavigation = (Shell.Current as Shell).CurrentItem?.CurrentItem?.Navigation;
            if (currentNavigation != null && currentNavigation.NavigationStack.Count > 1)
            {
                for (int i = currentNavigation.NavigationStack.Count - 1; i > 0; i--)
                {
                    currentNavigation.RemovePage(currentNavigation.NavigationStack[i]);
                }
            }
        }
    }
}
