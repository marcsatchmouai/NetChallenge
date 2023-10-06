using System;
using System.Collections.Generic;

namespace NetChallenge.Domain
{
    public class Office
    {
        private string _name;
        private int _maxCapacity;
        private IEnumerable<string> _avaiableResources;
        private int _id;
        private string _locationName;

        public int Id { get => _id; set => _id = value; }
        public string LocationName { get => _locationName; set => _locationName = value; }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre de la oficina no puede estar vacío o ser nulo.");
                }

                if (!string.IsNullOrEmpty(_name) && value.Trim() == _name.Trim())
                {
                    throw new ArgumentException("El nombre de la oficina no puede repetirse con la misma localizacion."); //ver esto
                }

                _name = value;
            }
        }

        public int MaxCapacity
        {
            get => _maxCapacity;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("La capacidad de la oficina debe ser mayor a cero.");
                }
                _maxCapacity = value;
            }
        }

        public IEnumerable<string> AvailableResources
        {
            get => _avaiableResources ?? (_avaiableResources = new List<string>());
            set => _avaiableResources = value;
        }
    }
}