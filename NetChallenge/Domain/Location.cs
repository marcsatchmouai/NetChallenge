using System.Collections.Generic;

namespace NetChallenge.Domain
{
    public class Location
    {
        public int Id { get; set; } // Identificador único del local
        public string Name { get; set; } // Nombre del local (no puede estar vacío)
        public string Neighborhood { get; set; } // Barrio del local (no puede estar vacío)
        public List<Office> Offices { get; } = new List<Office>(); // Lista de oficinas en este local

        // Restricciones:
        // - El nombre no puede estar vacío.
        // - El barrio no puede estar vacío.
        // - El nombre no puede repetirse.
    }

}