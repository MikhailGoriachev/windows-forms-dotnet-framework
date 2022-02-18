﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuToolbarTabControls.Models
{
    class Tablet
    {
        // модель планшета
        private string _title;
        public string Title {
            get => _title;
            set { _title = value; }
        } // Title

        // производитель планшета
        private string _company;
        public string Company {
            get => _company;
            set { _company = value; }
        } // Company

        // стоимость планшета
        private int _price;
        public int Price {
            get => _price;
            set { _price = value; }
        } // Price
    }
}
