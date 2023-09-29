using System.Collections.Generic;

namespace NetChallenge.Domain
{
    public class Office
    {
        public int Id { get; set; } // Identificador único de la oficina
        public string Name { get; set; } // Nombre de la oficina (no puede estar vacío)
        public int MaxCapacity { get; set; } // Capacidad máxima de la oficina (debe ser mayor a cero)
        public List<string> Resources { get; } = new List<string>(); // Recursos disponibles en la oficina
        public int LocationId { get; set; } // Identificador del local al que pertenece

        // Restricciones:
        // - El nombre no puede estar vacío.
        // - El nombre no puede repetirse dentro del mismo local.
        // - La capacidad máxima debe ser mayor a cero.
    }

}