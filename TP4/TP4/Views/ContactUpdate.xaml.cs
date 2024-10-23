
namespace TP4.Views;
using TP4.Models;

[QueryProperty(nameof(ContactId), nameof(ContactId))]
public partial class ContactUpdate : ContentPage
{
    private int contactId; // ID du contact à modifier
    private cListeContact _contactList;


    public int ContactId
    {
        set
        {
            contactId = value;
            LoadContact(); // Charger les informations du contact à modifier
        }
    }
    public ContactUpdate()
    {
		InitializeComponent();
        _contactList = new cListeContact("contacts.db");
        
        Routing.RegisterRoute($"{nameof(vContact)}", typeof(vContact));
        Routing.RegisterRoute($"{nameof(vListes)}", typeof(vListes));

    }
    private void LoadContact()
    {
        var contact = _contactList.GetList().Find(c => c.Id == contactId);
        if (contact != null)
        {
            editorNom.Text = contact.Name;
            editorMail.Text = contact.Email;
        }
    }
    private async void UpdateContact(object sender, EventArgs e)
    {
        // Créer un objet cContact mis à jour
        var updatedContact = new Models.cContact
        {
            Id = contactId,
            Name = editorNom.Text,
            Email = editorMail.Text
        };

        // Appeler la méthode Update pour mettre à jour le contact
        _contactList.UpdateContact(updatedContact);
         await DisplayAlert("Succès", "Le contact a été modifié avec succès.", "OK");
        await Shell.Current.GoToAsync("///MainPage"); // Retourner à la page précédente

    }
}