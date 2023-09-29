using System;

namespace NetChallenge.Domain
{
    public class Booking
    {
        public int Id { get; set; } // Identificador único de la reserva
        public DateTime StartTime { get; set; } // Hora de inicio de la reserva
        public TimeSpan Duration { get; set; } // Duración de la reserva (debe ser mayor a cero)
        public int OfficeId { get; set; } // Identificador de la oficina reservada
        public string UserId { get; set; } // Identificador del usuario que hace la reserva

        // Restricciones:
        // - La duración debe ser mayor a cero.
        // - No se debe superponer con otras reservas de la misma oficina.
        // - El usuario que hace la reserva es obligatorio.
    }

}