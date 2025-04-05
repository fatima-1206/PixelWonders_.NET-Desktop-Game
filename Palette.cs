using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelWonders
{
    internal class Palette
    {

        /// <summary>
        /// Class to store color palettes
        /// Includes methods to add, remove, and print palettes
        /// Palettes are stored as a dictionary of string keys and lists of string values
        /// Each key is the name of a palette, and each value is a list of color hex codes
        /// Palettes can be retrieved by name, added, removed, and printed
        /// The class also includes a few default palettes
        /// </summary>

        public static class ColorPalettes
        {
            public static Dictionary<string, List<string>> Palettes =
            new Dictionary<string, List<string>>
                {
            {
                "Earthy",
                new List<string> { "#582F0E", "#7F4F24", "#936639", "#A68A64", "#B6AD90", "#C2C5AA", "#A4AC86", "#656D4A", "#414833", "#333D29"
                }
            },
            {
                "Seashore",
                new List<string> { "#D9ED92", "#B5E48C", "#99D98C", "#76C893", "#52B69A", "#34A0A4", "#168AAD", "#1A759F", "#1E6091", "#184E77" }
            },
            {
                "Magma",
                new List<string> { "#03071E", "#370617", "#6A040F", "#9D0208", "#D00000", "#DC2F02", "#E85D04", "#F48C06", "#FAA307", "#FFBA08" }
            },
            {
                "Monochrome",
                new List<string> { "#F8F9FA", "#E9ECEF", "#DEE2E6", "#CED4DA", "#ADB5BD", "#6C757D", "#495057", "#343A40", "#212529" }
            },
            {
                "Cyborg",
                new List<string> { "#F72585", "#B5179E", "#7209B7", "#560BAD", "#480CA8", "#3A0CA3", "#3F37C9", "#4361EE", "#4895EF", "#4CC9F0" }
            },
            {
                "Blues",
                new List<string> { "#012A4A", "#013A63", "#01497C", "#014F86", "#2A6F97", "#2C7DA0", "#468FAF", "#61A5C2", "#89C2D9", "#A9D6E5" }
            },
            {
                "Pastel Rainbow",
                new List<string> { "#F94144", "#F3722C", "#F8961E", "#F9844A", "#F9C74F", "#90BE6D", "#43AA8B", "#4D908E", "#577590", "#277DA1" }
            },
            {
                "Ruby",
                new List<string> { "#590D22", "#800F2F", "#A4133C", "#C9184A", "#FF4D6D", "#FF758F", "#FF8FA3", "#FFB3C1", "#FFCCD5", "#FFF0F3" }
            },
            {
                "Purples",
                new List<string> { "#DEC9E9", "#DAC3E8", "#D2B7E5", "#C19EE0", "#B185DB", "#A06CD5", "#9163CB", "#815AC0", "#7251B5", "#6247AA" }
            }
                };

            public static List<string> GetPalette(string name)
            {
                return Palettes.ContainsKey(name) ? Palettes[name] : new List<string>();
            }

            public static void addPalette(string name, List<string> colors)
            {
                Palettes.Add(name, colors);
            }

            public static void removePalette(string name)
            {
                Palettes.Remove(name);
            }

            public static void printPalette(string name)
            {
                if (Palettes.ContainsKey(name))
                {
                    Console.WriteLine(name + " palette:");
                    foreach (string color in Palettes[name])
                    {
                        Console.WriteLine(color);
                    }
                }
                else
                {
                    Console.WriteLine("Palette not found.");
                }
            }

            public static void printAllPalettes()
            {
                foreach (KeyValuePair<string, List<string>> palette in Palettes)
                {
                    Console.WriteLine(palette.Key + " palette:");   
                    foreach (string color in palette.Value)
                    {
                        Console.WriteLine(color);
                    }
                }
            }
        }

    }
}
