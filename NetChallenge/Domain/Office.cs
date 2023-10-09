using NetChallenge.Exceptions;
using System;
using System.Collections.Generic;

namespace NetChallenge.Domain
{
    public class Office
    {
        private int _id;
        private string _name;
        private int _maxCapacity;
        private string _locationName;
        private IEnumerable<string> _avaiableResources;

        public int Id { get => _id; set => _id = value; }
        public string Name
        {
            get => _name;
            set
            {
                ValidationExtensions.ValidateIsNullOrWhiteSpace(value, "El nombre de la oficina no puede estar vacío o ser nulo.");

                ValidationExtensions.ValidateNotEqual(value, _name, "El nombre de la oficina no puede repetirse con la misma localizacion.");

                _name = value;
            }
        }
        public string LocationName { get => _locationName; set => _locationName = value; }
        public int MaxCapacity
        {
            get => _maxCapacity;
            set
            {
                ValidationExtensions.ValidateNotLessThanOrEqualZero(value, "La capacidad de la oficina debe ser mayor a cero.");
                
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