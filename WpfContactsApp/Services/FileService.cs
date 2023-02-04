using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using WpfContactsApp.MVVM.Models;

namespace WpfContactsApp.Services
{
    public class FileService
    {
        private string filePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\WpfContacts.json";
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
                contacts = JsonConvert.DeserializeObject<List<ContactModel>>(sr.ReadToEnd());
            }
            catch
            {
                contacts = new List<ContactModel>();
            }
        }

        public ObservableCollection<ContactModel> Contacts()
        {
            var items = new ObservableCollection<ContactModel>();
            foreach (var contact in contacts)
                items.Add(contact);

            return items;
        }





        private void SaveToFile()
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(JsonConvert.SerializeObject(contacts));
        }

        public void AddToList(ContactModel contact)
        {
            contacts.Add(contact);
            SaveToFile();
        }





        public void UpdateListItem(Guid id, ContactModel contact)
        {
            var item = contacts.FindAll(x => x.Id == id);
            var index = contacts.FindIndex(item => item.Id == id);
            
            try 
            {
                contacts.RemoveAt(index);
                contacts.Insert(index, contact);
                SaveToFile();
            }
            catch 
            {
                
            }
        }





        public void RemoveFromList(Guid id)
        {
            var item = contacts.FindAll(x => x.Id == id);
            var index = contacts.FindIndex(item => item.Id == id);
            contacts.RemoveAt(index);
            SaveToFile();
        }
    }
}
