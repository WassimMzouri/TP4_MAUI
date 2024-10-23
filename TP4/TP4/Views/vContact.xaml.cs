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

        // R�cup�rer les donn�es de l'utilisateur
        var nom = editorNom.Text;
        var email = editorMail.Text;

        // Construire la cha�ne de donn�es avec le s�parateur "$$"
        var sVal = $"{nom}$$ {email}";

        // Naviguer vers vListe en passant les donn�es
        await Shell.Current.GoToAsync($"{nameof(vListes)}?Name={sVal}");

        //// Cr�er un nouvel objet cContact
        //var newContact = new cContact
        //{
        //    Name = editorNom.ToString(), // Remplacez par le nom d�sir�
        //    Email = editorMail.ToString() // Remplacez par l'email d�sir�
        //};

        //// Appeler la m�thode CreateContact pour l'ajouter � la base de donn�es
        //int result = _contactList.CreateContact(newContact);

        //// Afficher un message si l'ajout a r�ussi
        //if (result > 0)
        //{
        //    DisplayAlert("Succ�s", "Le contact a �t� ajout� avec succ�s !", "OK");
        //}
        //else
        //{
        //    DisplayAlert("Erreur", "L'ajout du contact a �chou�.", "OK");
        //}
    }
}