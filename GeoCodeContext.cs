using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace GeoCodeClient
{
    public class GeoCodeContext : DbContext
    {
        public DbSet<AddressComponent> addressComponents { get; set; }
        public DbSet<GeoCode> geoCodes { get; set; }
        public DbSet<GeoCodeList> geoCodeLists { get; set; }
        public DbSet<Geometry> geometries { get; set; }
        public DbSet<Location> locations { get; set; }
        public DbSet<ViewPort> viewPorts { get; set; }
    }
}
