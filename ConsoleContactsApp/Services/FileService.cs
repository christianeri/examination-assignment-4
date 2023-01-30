using System.Collections.ObjectModel;
using Newtonsoft.Json;
using ConsoleContactsApp.Models;

namespace ConsoleContactsApp.Services
{
    public class FileService
    {
        private string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\ConsoleAppContacts.json";
        private List<ContactModel> contacts;

        public FileService()
        {
            ReadFromFile();
        }

        private void ReadFromFile()
        {
            try
            {
                using var sr = new StreamReader(filePath);
                contacts = JsonConvert.DeserializeObject<List<ContactModel>>(sr.ReadToEnd())!;
            }
            catch { contacts = new List<ContactModel>(); }
        }


        private void SaveToFile()
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(JsonConvert.SerializeObject(contacts));
        }

        public void AddListItem(ContactModel contact)
        {
            contacts.Add(contact);
            SaveToFile();
        }

        public List<ContactModel> AllContacts()
        {
            return contacts;
        }

        public ContactModel SingleContact(int index)
        {
            return contacts.ElementAt(index);
        }

        public void UpdateListItem(int index, ContactModel contact)
        {
            contacts.RemoveAt(index);
            SaveToFile();
            contacts.Insert(index, contact);
            SaveToFile();
        }

        public void RemoveListItem(int index)
        {
            contacts.RemoveAt(index);
            SaveToFile();
        }
    }
}
