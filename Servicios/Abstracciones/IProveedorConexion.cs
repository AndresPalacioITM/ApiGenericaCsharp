using System;
namespace ApiGenericaCsharp.Servicios.Abstracciones
{
    public interface IProveedorConexion
    {
        string ProveedorActual {get;}
        string ObtenerCadenaConexion();
    }
}