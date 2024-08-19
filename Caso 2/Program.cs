using System;
using System.Collections.Generic;


public class Tarea
{
    private string titulo;
    private string descripcion;
    private DateTime fechaLimite;

    public Tarea(string titulo, string descripcion, DateTime fechaLimite)
    {
        this.titulo = titulo;
        this.descripcion = descripcion;
        this.fechaLimite = fechaLimite;
    }

    //Metodos para obtener y establecer el titulo
    public void SetTitulo(string titulo)
    {
        this.titulo = titulo;
    }

    public string GetTitulo()
    {
        return titulo;
    }

    //Metodos para obtener y establecer la descripción
    public void SetDescripcion(string descripcion)
    {
        this.descripcion = descripcion;
    }

    public string GetDescripcion()
    {
        return descripcion;
    }

    //Metodos para obtener y establecer la fecha limite
    public void SetFechaLimite(DateTime fechaLimite)
    {
        this.fechaLimite = fechaLimite;
    }

    public DateTime GetFechaLimite()
    {
        return fechaLimite;
    }

    //Metodo virtual para mostrar detalles
    public virtual void MostrarDetalles()
    {
        Console.WriteLine($"Titulo: {titulo}, Descripción: {descripcion}, Fecha Límite: {fechaLimite.ToShortDateString()}");
    }
}

    
public class TareaUrgente : Tarea 
{
    private int nivelUrgencia;

    public TareaUrgente(string titulo, string descripcion, DateTime fechaLimite, int nivelUrgencia)
        : base(titulo, descripcion, fechaLimite)
    {
        this.nivelUrgencia = nivelUrgencia;
    }

    //Metodos para obtener y establecer el nivel de urgencia
    public void SetNivelUrgencia(int nivelUrgencia)
    {
        this.nivelUrgencia = nivelUrgencia;
    }

    public int GetNivelUrgencia()
    {
        return nivelUrgencia;
    }

    //Sobrescribe el metodo para incluir el nivel de urgencia
    public override void MostrarDetalles()
    {
        Console.WriteLine($"Titulo: {GetTitulo()}, Descripcion: {GetDescripcion()}, Fecha Limite: {GetFechaLimite().ToShortDateString()}, Nivel de Urgencia: {nivelUrgencia}");
    }
}

class Program
{
    //Lista para almacenar las tareas
    static List<Tarea> tareas = new List<Tarea>();

    static void Main(string[] args)
    {
        bool continuar = true; //Inicializamos la variable continuar
        do
        {
            Console.WriteLine("Menu Prinncipal:");
            Console.WriteLine("1. Agregar Tarea");
            Console.WriteLine("2. Ver Tareas");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opcion: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarTarea();
                    break;
                case "2":
                    VerTareas();
                    break;
                case "3":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no valida. Intente de nuevo.");
                    continuar = true;
                    break;
            }

        } while (continuar);
    }

    static void AgregarTarea()
    {
        Console.Write("Ingrese el título de la tarea: ");
        string titulo = Console.ReadLine();

        Console.Write("Ingrese la descripción de la tarea: ");
        string descripcion = Console.ReadLine();

        Console.Write("Ingrese la fecha límite de la tarea (dd/mm/yyyy): ");
        DateTime fechaLimite = DateTime.Parse(Console.ReadLine());

        Console.Write("Es una tarea urgente? (s/n): ");
        string esUrgente = Console.ReadLine();

        if (esUrgente.ToLower() == "s")
        {
            Console.Write("Ingrese el nivel de urgencia (1-10): ");
            int nivelUrgencia = int.Parse(Console.ReadLine());

            TareaUrgente nuevaTarea = new TareaUrgente(titulo, descripcion, fechaLimite, nivelUrgencia);
            tareas.Add(nuevaTarea);
        }
        else
        {
            Tarea nuevaTarea = new Tarea(titulo, descripcion, fechaLimite);
            tareas.Add(nuevaTarea);
        }

        Console.WriteLine("Tarea agregada con exito.\n");
    }

    static void VerTareas()
    {
        Console.WriteLine("\nLista de Tareas:");

        foreach (var tarea in tareas)
        {
            tarea.MostrarDetalles();
        }

        Console.WriteLine();
    }
}