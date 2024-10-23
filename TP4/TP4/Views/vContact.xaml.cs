using TP4.Models;

namespace TP4.Views;


public partial class vContact : ContentPage
{
    private cListeContact _contactList;

    public vContact()
    {
		InitializeComponent();
       
        Routing.RegisterRoute($"{nameof(vListes)}", typeof(vListes));


    }




    private async void OnSaveClicked(object sender, EventArgs e)
    {

        // Récupérer les données de l'utilisateur
        var nom = editorNom.Text;
        var email = editorMail.Text;

        // Construire la chaîne de données avec le séparateur "$$"
        var sVal = $"{nom}$$ {email}";

        // Naviguer vers vListe en passant les données
        await Shell.Current.GoToAsync($"{nameof(vListes)}?Name={sVal}");

        //// Créer un nouvel objet cContact
        //var newContact = new cContact
        //{
        //    Name = editorNom.ToString(), // Remplacez par le nom désiré
        //    Email = editorMail.ToString() // Remplacez par l'email désiré
        //};

        //// Appeler la méthode CreateContact pour l'ajouter à la base de données
        //int result = _contactList.CreateContact(newContact);

        //// Afficher un message si l'ajout a réussi
        //if (result > 0)
        //{
        //    DisplayAlert("Succès", "Le contact a été ajouté avec succès !", "OK");
        //}
        //else
        //{
        //    DisplayAlert("Erreur", "L'ajout du contact a échoué.", "OK");
        //}
    }
}