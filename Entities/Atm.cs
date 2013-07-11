using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoCodeClient.Entities
{
    public class Atm
    {
        private AtmType atmType;

        public AtmType AtmType { get { return atmType; } }

        public string AtmTypeString
        {
            set
            {
                switch (value)
                {
                    case "bankomat":
                        atmType = Entities.AtmType.Withdrawal;
                        break;
                    case "wpłatomat":
                        atmType = Entities.AtmType.Input;
                        break;
                    case "placówka":
                        atmType = Entities.AtmType.Outlet;
                        break;
                }
            }
        }
        public string Name { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Hours { get; set; }
    }
}
