using System;
using System.Collections.Generic;
using System.Linq;

namespace Re_useable_Classes.Converters
{
    public static class SpeedConverter
    {
        public static double SpeedConvert
            (
            string btnLstFrom,
            string btnLstTo,
            string txtFromValue)
        {
            if ((btnLstFrom.Equals("Meter/second") && (btnLstTo.Equals("Meter/second"))))
            {
                return Convert.ToDouble(txtFromValue);
            }

            if ((btnLstFrom.Equals("Meter/second") && (btnLstTo.Equals("Meter/minute"))))
            {
                return txtFromValue.Contains('.')
                           ? Convert.ToDouble(txtFromValue) * 59.988
                           : Convert.ToInt32(txtFromValue) * 59.988;
            }

            if ((btnLstFrom.Equals("Meter/second") && (btnLstTo.Equals("Kilometer/hour"))))
            {
                return txtFromValue.Contains('.')
                           ? Convert.ToDouble(txtFromValue) * 3.599712
                           : Convert.ToInt32(txtFromValue) * 3.599712;
            }

            if ((btnLstFrom.Equals("Meter/second") && (btnLstTo.Equals("Foot/second"))))
            {
                return txtFromValue.Contains('.')
                           ? Convert.ToDouble(txtFromValue) * 3.28084
                           : Convert.ToInt32(txtFromValue) * 3.28084;
            }

            if ((btnLstFrom.Equals("Meter/second") && (btnLstTo.Equals("Foot/minute"))))
            {
                return txtFromValue.Contains('.')
                           ? Convert.ToDouble(txtFromValue) * 196.8504
                           : Convert.ToInt32(txtFromValue) * 196.8504;
            }

            if ((btnLstFrom.Equals("Meter/second") && (btnLstTo.Equals("Miles/hour"))))
            {
                return txtFromValue.Contains('.')
                           ? Convert.ToDouble(txtFromValue) * 2.237136
                           : Convert.ToInt32(txtFromValue) * 2.237136;
            }
            return 0;
        }

        public class SpeedList : List<SpeedUnit>
        {
            public SpeedList()
            {
                Add
                    (
                        new SpeedUnit
                        {
                            SpeedUnits = "Meter/second"
                        });

                Add
                    (
                        new SpeedUnit
                        {
                            SpeedUnits = "Meter/minute"
                        });

                Add
                    (
                        new SpeedUnit
                        {
                            SpeedUnits = "Kilometer/hour "
                        });

                Add
                    (
                        new SpeedUnit
                        {
                            SpeedUnits = "Foot/second"
                        });

                Add
                    (
                        new SpeedUnit
                        {
                            SpeedUnits = "Foot/minute"
                        });

                Add
                    (
                        new SpeedUnit
                        {
                            SpeedUnits = "Miles/hour"
                        });
            }
        }

        public class SpeedUnit
        {
            public string SpeedUnits { get; set; }
        }
    }
}