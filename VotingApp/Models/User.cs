﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.Models
{
    public class User
    {
        private string lastName;

        private string firstNames;

        private string dateOfBirth;

        private string electoralID;

        public string ElectoralID
        {
            get { return electoralID; }
            set { electoralID = value; }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public string FirstNames
        {
            get
            {
                return firstNames;
            }

            set
            {
                firstNames = value;
            }
        }

        public string DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }

            set
            {
                dateOfBirth = value;
            }
        }
    }
}