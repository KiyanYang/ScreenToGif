﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ScreenToGif.Settings
{
    public class Property
    {
        public string NameSpace { get; set; }
        
        public string Key { get; set; }
        
        public string Type { get; set; }

        public string Value { get; set; }
        
        public List<Property> Attributes { get; set; } = new List<Property>();
        
        public List<Property> Children { get; set; } = new List<Property>();


        public override string ToString()
        {
            return $"NameSpace: {NameSpace}" + Environment.NewLine +
                   $"Key: {Key}" + Environment.NewLine +
                   $"Type: {Type}" + Environment.NewLine +
                   $"Value: {Value}" + Environment.NewLine +
                   $"Attributes: \"{Attributes.Aggregate("", (p, n) => p + (p.Length > 0 ? ", " : "") + n)}\"";
        }
    }
}