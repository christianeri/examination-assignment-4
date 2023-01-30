using ConsoleContactsApp.Services;

var menu = new MenuService();

menu.FilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\ConcoleAppContacts.json";

while (true)
{
    Console.Clear();
    menu.WelcomeMenu();
}
