using System;
using System.Collections.Generic;

namespace NetChallenge.Domain
{
    public class Location
    {
        private string _name;
        private string _neighborhood;
        private List<Office> _offices;
        private int _id;

        public int Id { get => _id; set => _id = value; }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre de la localizacion no puede estar vacío o ser nulo.");
                }

                if (!string.IsNullOrEmpty(_name) && value.Trim() == _name.Trim())
                {
                    throw new ArgumentException("El nombre de la localizacion no puede repetirse.");
                }

                _name = value;
            }
        }

        public string Neighborhood
        {
            get => _neighborhood;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El barrio no puede estar vacío o ser nulo.");
                }
                _neighborhood = value;
            }
        }

        public List<Office> Offices
        {
            get => _offices ?? (_offices = new List<Office>());
            set => _offices = value;
        }
    }
}
