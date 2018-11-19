using System.Collections.Generic;

namespace Re_useable_Classes.Converters
{
    public static class LengthConverter
    {
        public static double LengthConvert
            (
            string btnFrom,
            string btnTo,
            double txtFromValue)
        {
            string f = btnFrom;
            string t = btnTo;
            double fromVal = txtFromValue;
            if (f == "Millimeters" && t == "Centimeters")
            {
                double x = fromVal * 0.1;
                return x;
            }
            if (f == "Millimeters" && t == "Meters")
            {
                double x = fromVal * 0.001;
                return x;
            }
            if (f == "Millimeters" && t == "Kilometers")
            {
                double x = fromVal * 0.000001;
                return x;
            }
            if (f == "Millimeters" && t == "Inches")
            {
                double x = fromVal * 0.03937;
                return x;
            }
            if (f == "Millimeters" && t == "Feet")
            {
                double x = fromVal * 0.003281;
                return x;
            }
            if (f == "Millimeters" && t == "0.001094")
            {
                double x = fromVal * 0.1;
                return x;
            }
            if (f == "Millimeters" && t == "Miles")
            {
                double x = fromVal * 6.21e-07;
                return x;
            }
            if (f == "Millimeters" && t == "Millimeters")
            {
                double x = fromVal * 1;
                return x;
            }
            // Centimeters //
            if (f == "Centimeters" && t == "Millimeters")
            {
                double x = fromVal * 10;
                return x;
            }
            if (f == "Centimeters" && t == "Meters")
            {
                double x = fromVal * 0.01;
                return x;
            }
            if (f == "Centimeters" && t == "Kilometers")
            {
                double x = fromVal * 0.00001;
                return x;
            }
            if (f == "Centimeters" && t == "Inches")
            {
                double x = fromVal * 0.393701;
                return x;
            }
            if (f == "Centimeters" && t == "Feet")
            {
                double x = fromVal * 0.032808;
                return x;
            }
            if (f == "Centimeters" && t == "Yards")
            {
                double x = fromVal * 0.010936;
                return x;
            }
            if (f == "Centimeters" && t == "Miles")
            {
                double x = fromVal * 0.000006;
                return x;
            }
            if (f == "Centimeters" && t == "Centimeters")
            {
                double x = fromVal * 1;
                return x;
            }
            // Meters //
            if (f == "Meters" && t == "Millimeters")
            {
                double x = fromVal * 1000;
                return x;
            }
            if (f == "Meters" && t == "Centimeters")
            {
                double x = fromVal * 100;
                return x;
            }
            if (f == "Meters" && t == "Kilometers")
            {
                double x = fromVal * 0.001;
                return x;
            }
            if (f == "Meters" && t == "Inches")
            {
                double x = fromVal * 39.37008;
                return x;
            }
            if (f == "Meters" && t == "Feet")
            {
                double x = fromVal * 3.28084;
                return x;
            }
            if (f == "Meters" && t == "Yards")
            {
                double x = fromVal * 1.093613;
                return x;
            }
            if (f == "Meters" && t == "Miles")
            {
                double x = fromVal * 0.000621;
                return x;
            }
            if (f == "Meters" && t == "Meters")
            {
                double x = fromVal * 1;
                return x;
            }
            // Kilometers //
            if (f == "Kilometers" && t == "Millimeters")
            {
                double x = fromVal * 1000000;
                return x;
            }
            if (f == "Kilometers" && t == "Centimeters")
            {
                double x = fromVal * 100000;
                return x;
            }
            if (f == "Kilometers" && t == "Meters")
            {
                double x = fromVal * 1000;
                return x;
            }
            if (f == "Kilometers" && t == "Inches")
            {
                double x = fromVal * 39370.08;
                return x;
            }
            if (f == "Kilometers" && t == "Feet")
            {
                double x = fromVal * 3280.84;
                return x;
            }
            if (f == "Kilometers" && t == "Yards")
            {
                double x = fromVal * 1093.613;
                return x;
            }
            if (f == "Kilometers" && t == "Miles")
            {
                double x = fromVal * 0.621371;
                return x;
            }
            if (f == "Kilometers" && t == "Kilometers")
            {
                double x = fromVal * 1;
                return x;
            }
            // Inches //
            if (f == "Inches" && t == "Millimeters")
            {
                double x = fromVal * 25.4;
                return x;
            }
            if (f == "Inches" && t == "Centimeters")
            {
                double x = fromVal * 2.54;
                return x;
            }
            if (f == "Inches" && t == "Meters")
            {
                double x = fromVal * 0.0254;
                return x;
            }
            if (f == "Inches" && t == "Kilometers")
            {
                double x = fromVal * 0.000025;
                return x;
            }
            if (f == "Inches" && t == "Feet")
            {
                double x = fromVal * 0.083333;
                return x;
            }
            if (f == "Inches" && t == "Yards")
            {
                double x = fromVal * 0.027778;
                return x;
            }
            if (f == "Inches" && t == "Miles")
            {
                double x = fromVal * 0.000016;
                return x;
            }
            if (f == "Inches" && t == "Inches")
            {
                double x = fromVal * 1;
                return x;
            }
            // Feet //
            if (f == "Feet" && t == "Millimeters")
            {
                double x = fromVal * 304.8;
                return x;
            }
            if (f == "Feet" && t == "Centimeters")
            {
                double x = fromVal * 30.48;
                return x;
            }
            if (f == "Feet" && t == "Meters")
            {
                double x = fromVal * 0.3048;
                return x;
            }
            if (f == "Feet" && t == "Kilometers")
            {
                double x = fromVal * 0.000305;
                return x;
            }
            if (f == "Feet" && t == "Inches")
            {
                double x = fromVal * 12;
                return x;
            }
            if (f == "Feet" && t == "Yards")
            {
                double x = fromVal * 0.333333;
                return x;
            }
            if (f == "Feet" && t == "Miles")
            {
                double x = fromVal * 0.000189;
                return x;
            }
            if (f == "Feet" && t == "Feet")
            {
                double x = fromVal * 1;
                return x;
            }
            // Yards //
            if (f == "Yards" && t == "Millimeters")
            {
                double x = fromVal * 914.4;
                return x;
            }
            if (f == "Yards" && t == "Centimeters")
            {
                double x = fromVal * 91.44;
                return x;
            }
            if (f == "Yards" && t == "Meters")
            {
                double x = fromVal * 0.9144;
                return x;
            }
            if (f == "Yards" && t == "Kilometers")
            {
                double x = fromVal * 0.000914;
                return x;
            }
            if (f == "Yards" && t == "Inches")
            {
                double x = fromVal * 36;
                return x;
            }
            if (f == "Yards" && t == "Feet")
            {
                double x = fromVal * 3;
                return x;
            }
            if (f == "Yards" && t == "Miles")
            {
                double x = fromVal * 0.000568;
                return x;
            }
            if (f == "Yards" && t == "Yards")
            {
                double x = fromVal * 1;
                return x;
            }
            // Miles //
            if (f == "Miles" && t == "Millimeters")
            {
                double x = fromVal * 1609344;
                return x;
            }
            if (f == "Miles" && t == "Centimeters")
            {
                double x = fromVal * 160934.4;
                return x;
            }
            if (f == "Miles" && t == "Meters")
            {
                double x = fromVal * 1609.344;
                return x;
            }
            if (f == "Miles" && t == "Kilometers")
            {
                double x = fromVal * 1.609344;
                return x;
            }
            if (f == "Miles" && t == "Inches")
            {
                double x = fromVal * 63360;
                return x;
            }
            if (f == "Miles" && t == "Feet")
            {
                double x = fromVal * 5280;
                return x;
            }
            if (f == "Miles" && t == "Yards")
            {
                double x = fromVal * 1760;
                return x;
            }
            if (f == "Miles" && t == "Miles")
            {
                double x = fromVal * 1;
                return x;
            }
            return 0;
        }

        public class LengthList : List<LengthUnit>
        {
            public LengthList()
            {
                Add
                    (
                        new LengthUnit
                        {
                            LengthUnits = "Millimeters"
                        });

                Add
                    (
                        new LengthUnit
                        {
                            LengthUnits = "Centimeters"
                        });

                Add
                    (
                        new LengthUnit
                        {
                            LengthUnits = "Meters"
                        });

                Add
                    (
                        new LengthUnit
                        {
                            LengthUnits = "Kilometers"
                        });

                Add
                    (
                        new LengthUnit
                        {
                            LengthUnits = "Inches"
                        });

                Add
                    (
                        new LengthUnit
                        {
                            LengthUnits = "Feet"
                        });

                Add
                    (
                        new LengthUnit
                        {
                            LengthUnits = "Yards"
                        });

                Add
                    (
                        new LengthUnit
                        {
                            LengthUnits = "Miles"
                        });
            }
        }

        public class LengthUnit
        {
            public string LengthUnits { get; set; }
        }
    }
}