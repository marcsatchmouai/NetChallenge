using System;
using System.Collections.Generic;
using NetChallenge.Exceptions;

namespace NetChallenge.Domain
{
    public class Location
    {
        private int _id;
        private string _name;
        private string _neighborhood;

        public int Id { get => _id; set => _id = value; }

        public string Name
        {
            get => _name;
            set
            {
                ValidationExtensions.ValidateIsNullOrWhiteSpace(value, "El nombre de la localización no puede estar vacío o ser nulo.");

                ValidationExtensions.ValidateNotEqual(value, _name, "El nombre de la localizacion no puede repetirse.");

                _name = value;
            }
        }

        public string Neighborhood
        {
            get => _neighborhood;
            set
            {
                ValidationExtensions.ValidateIsNullOrWhiteSpace(value, "El barrio no puede estar vacío o ser nulo.");
                
                _neighborhood = value;
            }
        }
    }
}
