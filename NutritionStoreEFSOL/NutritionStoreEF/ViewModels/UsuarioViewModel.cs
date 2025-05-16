using NutritionStoreEF.Models;
using NutritionStoreEF.Service;
using NutritionStoreEF.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

public class UsuarioViewModel : INotifyPropertyChanged
{
    #region Variables
    private UsuarioService usuarioService = new UsuarioService();
    private SuplementoService suplementoService = new SuplementoService();
    private EjercicioService ejercicioService = new EjercicioService();
    #endregion

    #region Propiedades
    private ObservableCollection<Usuario> _usuarios;
    public ObservableCollection<Usuario> Usuarios
    {
        get { return _usuarios; }
        set { _usuarios = value; OnPropertyChanged(nameof(Usuarios)); }
    }

    private ObservableCollection<Suplemento> _suplementos;
    public ObservableCollection<Suplemento> Suplementos
    {
        get { return _suplementos; }
        set { _suplementos = value; OnPropertyChanged(nameof(Suplementos)); }
    }

    private ObservableCollection<Ejercicio> _ejercicios;
    public ObservableCollection<Ejercicio> Ejercicios
    {
        get { return _ejercicios; }
        set { _ejercicios = value; OnPropertyChanged(nameof(Ejercicios)); }
    }

    #endregion


    #region Comandos
    public RelayCommand CargarUsuariosCommand { get; set; }
    public RelayCommand CargarSuplementosCommand { get; set; }
    public RelayCommand CargarEjerciciosCommand { get; set; }
    public RelayCommand AgregarUsuarioCommand { get; set; }
    public RelayCommand AgregarSuplementoCommand { get; set; }
    public RelayCommand AgregarEjercicioCommand { get; set; }
    #endregion

    #region Constructor
    public UsuarioViewModel()
    {

    }
    #endregion


    #region Metodos
    private void LoadUsuarios()
    {
        Usuarios = usuarioService.GetAllUsuarios();
    }

    private void LoadSuplementos()
    {
        Suplementos = suplementoService.GetAllSuplementos();
    }

    private void LoadEjercicios()
    {
        Ejercicios = ejercicioService.GetAllEjercicios();
    }

    private void AddUsuario(Usuario usuario)
    {
        usuarioService.AddUsuario(usuario);
        LoadUsuarios();
    }

    private void AddSuplemento(Suplemento suplemento)
    {
        suplementoService.AddSuplemento(suplemento);
        LoadSuplementos();
    }

    private void AddEjercicio(Ejercicio ejercicio)
    {
        ejercicioService.AddEjercicio(ejercicio);
        LoadEjercicios();
    }

    private void UpdateUsuario(Usuario updatedUsuario)
    {
        usuarioService.UpdateUsuario(updatedUsuario);
        LoadUsuarios(); 
    }

    private void UpdateSuplemento(Suplemento updatedSuplemento)
    {
        suplementoService.UpdateSuplemento(updatedSuplemento);
        LoadSuplementos();
    }

    private void UpdateEjercicio(Ejercicio updatedEjercicio)
    {
        ejercicioService.UpdateEjercicio(updatedEjercicio);
        LoadEjercicios();
    }

    private void RemoveUsuario(Usuario usuario)
    {
        usuarioService.RemoveUsuario(usuario);
        LoadUsuarios();
    }

    private void RemoveSuplemento(Suplemento suplemento)
    {
        suplementoService.RemoveSuplemento(suplemento.ID);
        LoadSuplementos();
    }

    private void RemoveEjercicio(Ejercicio ejercicio)
    {
        ejercicioService.RemoveEjercicio(ejercicio);
        LoadEjercicios();
    }
    #endregion

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
