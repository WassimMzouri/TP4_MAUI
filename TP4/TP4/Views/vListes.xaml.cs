using TP4.Models;

namespace TP4.Views;

[QueryProperty(nameof(Name), nameof(Name))]
public partial class vListes : ContentPage
{
    private cListeContact _contactList;

    public vListes()
    {
		InitializeComponent();
        _contactList = new cListeContact("contacts.db");

        Routing.RegisterRoute($"{nameof(vContact)}", typeof(vContact));

        LoadContacts();
    }


    private void LoadContacts()
    {
        var contacts = _contactList.GetList();
        cvListeContact.ItemsSource = contacts;
    }

    public string Name
    {
        set
        {
            // Récupérer le nom et l'email de la chaîne envoyée
            var data = value.Split("$$");
            var nom = data[0];
            var email = data[1];

            // Créer un nouvel objet cContact avec les données reçues
            var newContact = new cContact
            {
                Name = nom,
                Email = email
            };

            // Appeler CreateContact pour ajouter le contact à la base de données
            _contactList.CreateContact(newContact);

            // Mettre à jour la liste affichée
            //LoadContacts();
        }
    }



    private async void Add_Clicked(object sender, EventArgs e)
    {
       

        await Navigation.PushAsync(new vContact());


    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        lbContacts.Text ="Nombre : " + _contactList.GetList().Count.ToString();


        cvListeContact.ItemsSource =_contactList.GetList();

    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        // Vérifier que l'élément sélectionné n'est pas nul
        if (cvListeContact.SelectedItem is cContact selectedContact)
        {
            // Appeler la méthode DeleteContact pour supprimer le contact
            _contactList.DeleteContact(selectedContact);
            LoadContacts();
        }

    }

    private async void OnEditClicked(object sender, EventArgs e)
    {
        // Vérifier que l'élément sélectionné n'est pas nul
        if (cvListeContact.SelectedItem is cContact selectedContact)
        {
            // Naviguer vers vModifierContact en passant l'ID du contact
            //await Shell.Current.GoToAsync($"{nameof(ContactUpdate)}?ContactId={selectedContact.Id}");
            await Shell.Current.GoToAsync($"///ContactUpdate?ContactId={selectedContact.Id}");

        }
        else
        {
            await DisplayAlert("Erreur", "Veuillez sélectionner un contact à modifier.", "OK");
        }
    }



}