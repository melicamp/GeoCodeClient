using GeoCodeClient.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GeoCodeClient
{
    public class FileLoader
    {
        string fileName = "pok.csv";

        public List<Atm> GetAtmList()
        {
            var list = new List<Atm>();
            var file = new FileStream(fileName, FileMode.Open);

            using (var sr = new StreamReader(file))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();

                    var splitted = line.Split(';');

                    list.Add(new Atm
                    {
                        AtmTypeString = splitted[0],
                        Name = splitted[1],
                        Province = splitted[2],
                        City = splitted[3],
                        Street = splitted[4],
                        Hours = splitted[5]
                    });
                }
            }

            return list;
        }  
    }
}
