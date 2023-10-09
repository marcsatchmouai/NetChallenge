using NetChallenge.Exceptions;
using System;

namespace NetChallenge.Domain
{
    public class Booking
    {
        private int _id; 
        private DateTime _dateTime;
        private TimeSpan _duration;
        private string _officeName;
        private string _userName;
        private string _locationName;
        //private DateTime _finishTime;

        public int Id { get => _id; set => _id = value; }

        public string LocationName { get => _locationName; set => _locationName = value; }

        //public DateTime FinishTime { get => _finishTime; set => _finishTime = _dateTime.Add(_duration); }

        public DateTime DateTime
        {
            get => _dateTime;
            set
            {
                ValidationExtensions.ValidateNotInPast(value, "La hora de inicio de la reserva no puede ser en el pasado.");

                _dateTime = value;
            }
        }

        public TimeSpan Duration
        {
            get => _duration;
            set
            {
                ValidationExtensions.ValidateIsInHours(value, "La duración debe ser un periodo de tiempo en horas.");
                
                _duration = value;
            }
        }

        public string OfficeName
        {
            get => _officeName;
            set
            {
                ValidationExtensions.ValidateIsNullOrWhiteSpace(value, "El ID de la oficina debe ser mayor a cero.");
                
                _officeName = value;
            }
        }

        public string UserName
        {
            get => _userName;
            set
            {
                ValidationExtensions.ValidateIsNullOrWhiteSpace(value, "El nombre del usuario no puede estar vacío o ser nulo.");
                
                _userName = value;
            }
        }
    }
}