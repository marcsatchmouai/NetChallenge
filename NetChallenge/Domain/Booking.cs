using System;
using System.Runtime.ConstrainedExecution;

namespace NetChallenge.Domain
{
    public class Booking
    {
        // Restricciones:
        //- Debe pertenecer a una oficina válida.
        //- Debe tener una duración mayor a cero.
>       //- No se debe superponer con otras reservas de la misma oficina.
>       //- El usuario que hace la reserva es obligatorio.

        private int _id; 
        private DateTime _startTime;
        private TimeSpan _duration;
        private string _officeName;
        private string _userName;
        private string _locationName;
        private DateTime _finishTime;

        public int Id { get => _id; set => _id = value; }

        public string LocationName { get => _locationName; set => _locationName = value; }

        public DateTime FinishTime { get => _finishTime; set => _finishTime = _startTime.Add(_duration); }

        public DateTime StartTime
        {
            get => _startTime;
            set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentException("La hora de inicio de la reserva no puede ser en el pasado.");
                }
                _startTime = value;
            }
        }

        public TimeSpan Duration
        {
            get => _duration;
            set
            {
                if (!(value.TotalMinutes % 60 == 0 && value.Seconds == 0 && value.Milliseconds == 0))
                {
                    throw new ArgumentException("La duración debe ser un periodo de tiempo en horas.");
                }
                _duration = value;
            }
        }

        public string OfficeName
        {
            get => _officeName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El ID de la oficina debe ser mayor a cero.");
                }
                _officeName = value;
            }
        }

        public string UserName
        {
            get => _userName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre del usuario no puede estar vacío o ser nulo.");
                }
                _userName = value;
            }
        }
    }
}