using System;
using System.Collections.Generic;

namespace Re_useable_Classes.Converters
{
    public static class MassConverter
    {
        public static double MassConvert
            (
            string btnLstFrom,
            string btnLstTo,
            string txtFromValue)
        {
            if ((btnLstFrom.Equals("Grams") && (btnLstTo.Equals("Grams"))))
            {
                return Convert.ToDouble(txtFromValue);
            }
            if ((btnLstFrom.Equals("Grams") && (btnLstTo.Equals("Kilograms"))))
            {
                return (Convert.ToDouble(txtFromValue) * 0.001);
            }
            if ((btnLstFrom.Equals("Grams") && (btnLstTo.Equals("Metric tonnes"))))
            {
                return (Convert.ToDouble(txtFromValue) * 0.000001);
            }
            if ((btnLstFrom.Equals("Grams") && (btnLstTo.Equals("Short ton"))))
            {
                return (Convert.ToDouble(txtFromValue) * 0.000001);
            }
            if ((btnLstFrom.Equals("Grams") && (btnLstTo.Equals("Long ton"))))
            {
                return (Convert.ToDouble(txtFromValue) * 9.84e-07);
            }
            if ((btnLstFrom.Equals("Grams") && (btnLstTo.Equals("Pounds"))))
            {
                return (Convert.ToDouble(txtFromValue) * 0.002205);
            }
            if ((btnLstFrom.Equals("Grams") && (btnLstTo.Equals("Ounces"))))
            {
                return (Convert.ToDouble(txtFromValue) * 0.035273);
            }

            // Kilograms //

            if ((btnLstFrom.Equals("Kilograms") && (btnLstTo.Equals("Grams"))))
            {
                return (Convert.ToDouble(txtFromValue) * 1000);
            }
            if ((btnLstFrom.Equals("Kilograms") && (btnLstTo.Equals("Kilograms"))))
            {
                return Convert.ToDouble(txtFromValue);
            }
            if ((btnLstFrom.Equals("Kilograms") && (btnLstTo.Equals("Metric tonnes"))))
            {
                return (Convert.ToDouble(txtFromValue) * 0.001);
            }
            if ((btnLstFrom.Equals("Kilograms") && (btnLstTo.Equals("Short ton"))))
            {
                return (Convert.ToDouble(txtFromValue) * 0.001102);
            }
            if ((btnLstFrom.Equals("Kilograms") && (btnLstTo.Equals("Long ton"))))
            {
                return (Convert.ToDouble(txtFromValue) * 0.000984);
            }
            if ((btnLstFrom.Equals("Kilograms") && (btnLstTo.Equals("Pounds"))))
            {
                return (Convert.ToDouble(txtFromValue) * 2.204586);
            }
            if ((btnLstFrom.Equals("Kilograms") && (btnLstTo.Equals("Ounces"))))
            {
                return (Convert.ToDouble(txtFromValue) * 35.27337);
            }

            // Metric tonnes //

            if ((btnLstFrom.Equals("Metric tonnes") && (btnLstTo.Equals("Grams"))))
            {
                return (Convert.ToDouble(txtFromValue) * 1000000);
            }
            if ((btnLstFrom.Equals("Metric tonnes") && (btnLstTo.Equals("Kilograms"))))
            {
                return (Convert.ToDouble(txtFromValue) * 1000);
            }
            if ((btnLstFrom.Equals("Metric tonnes") && (btnLstTo.Equals("Metric tonnes"))))
            {
                return Convert.ToDouble(txtFromValue);
            }
            if ((btnLstFrom.Equals("Metric tonnes") && (btnLstTo.Equals("Short ton"))))
            {
                return (Convert.ToDouble(txtFromValue) * 1.102293);
            }
            if ((btnLstFrom.Equals("Metric tonnes") && (btnLstTo.Equals("Long ton"))))
            {
                return (Convert.ToDouble(txtFromValue) * 0.984252);
            }
            if ((btnLstFrom.Equals("Metric tonnes") && (btnLstTo.Equals("Pounds"))))
            {
                return (Convert.ToDouble(txtFromValue) * 2204.586);
            }
            if ((btnLstFrom.Equals("Metric tonnes") && (btnLstTo.Equals("Ounces"))))
            {
                return (Convert.ToDouble(txtFromValue) * 35273.37);
            }

            // Short ton //

            if ((btnLstFrom.Equals("Short ton") && (btnLstTo.Equals("Grams"))))
            {
                return (Convert.ToDouble(txtFromValue) * 907200);
            }
            if ((btnLstFrom.Equals("Short ton") && (btnLstTo.Equals("Kilograms"))))
            {
                return (Convert.ToDouble(txtFromValue) * 907.2);
            }
            if ((btnLstFrom.Equals("Short ton") && (btnLstTo.Equals("Metric tonnes"))))
            {
                return (Convert.ToDouble(txtFromValue) * 0.9072);
            }
            if ((btnLstFrom.Equals("Short ton") && (btnLstTo.Equals("Short ton"))))
            {
                return Convert.ToDouble(txtFromValue);
            }
            if ((btnLstFrom.Equals("Short ton") && (btnLstTo.Equals("Long ton"))))
            {
                return (Convert.ToDouble(txtFromValue) * 0.892913);
            }
            if ((btnLstFrom.Equals("Short ton") && (btnLstTo.Equals("Pounds"))))
            {
                return (Convert.ToDouble(txtFromValue) * 2000);
            }
            if ((btnLstFrom.Equals("Short ton") && (btnLstTo.Equals("Ounces"))))
            {
                return (Convert.ToDouble(txtFromValue) * 32000);
            }

            // Long ton //

            if ((btnLstFrom.Equals("Long ton") && (btnLstTo.Equals("Grams"))))
            {
                return (Convert.ToDouble(txtFromValue) * 1016000);
            }
            if ((btnLstFrom.Equals("Long ton") && (btnLstTo.Equals("Kilograms"))))
            {
                return (Convert.ToDouble(txtFromValue) * 1016);
            }
            if ((btnLstFrom.Equals("Long ton") && (btnLstTo.Equals("Metric tonnes"))))
            {
                return (Convert.ToDouble(txtFromValue) * 1.016);
            }
            if ((btnLstFrom.Equals("Long ton") && (btnLstTo.Equals("Short ton"))))
            {
                return (Convert.ToDouble(txtFromValue) * 1.119929);
            }
            if ((btnLstFrom.Equals("Long ton") && (btnLstTo.Equals("Long ton"))))
            {
                return Convert.ToDouble(txtFromValue);
            }
            if ((btnLstFrom.Equals("Long ton") && (btnLstTo.Equals("Pounds"))))
            {
                return (Convert.ToDouble(txtFromValue) * 2239.859);
            }
            if ((btnLstFrom.Equals("Long ton") && (btnLstTo.Equals("Ounces"))))
            {
                return (Convert.ToDouble(txtFromValue) * 35837.74);
            }

            // Pounds//

            if ((btnLstFrom.Equals("Pounds") && (btnLstTo.Equals("Grams"))))
            {
                return (Convert.ToDouble(txtFromValue) * 453.6);
            }
            if ((btnLstFrom.Equals("Pounds") && (btnLstTo.Equals("Kilograms"))))
            {
                return (Convert.ToDouble(txtFromValue) * 0.4536);
            }
            if ((btnLstFrom.Equals("Pounds") && (btnLstTo.Equals("Metric tonnes"))))
            {
                return (Convert.ToDouble(txtFromValue) * 0.000454);
            }
            if ((btnLstFrom.Equals("Pounds") && (btnLstTo.Equals("Short ton"))))
            {
                return (Convert.ToDouble(txtFromValue) * 0.0005);
            }
            if ((btnLstFrom.Equals("Pounds") && (btnLstTo.Equals("Long ton"))))
            {
                return (Convert.ToDouble(txtFromValue) * 0.000446);
            }
            if ((btnLstFrom.Equals("Pounds") && (btnLstTo.Equals("Pounds"))))
            {
                return Convert.ToDouble(txtFromValue);
            }
            if ((btnLstFrom.Equals("Pounds") && (btnLstTo.Equals("Ounces"))))
            {
                return (Convert.ToDouble(txtFromValue) * 16);
            }

            // Ounces //

            if ((btnLstFrom.Equals("Ounces") && (btnLstTo.Equals("Grams"))))
            {
                return (Convert.ToDouble(txtFromValue) * 28);
            }
            if ((btnLstFrom.Equals("Ounces") && (btnLstTo.Equals("Kilograms"))))
            {
                return (Convert.ToDouble(txtFromValue) * 0.02835);
            }
            if ((btnLstFrom.Equals("Ounces") && (btnLstTo.Equals("Metric tonnes"))))
            {
                return (Convert.ToDouble(txtFromValue) * 0.000028);
            }
            if ((btnLstFrom.Equals("Ounces") && (btnLstTo.Equals("Short ton"))))
            {
                return (Convert.ToDouble(txtFromValue) * 0.000031);
            }
            if ((btnLstFrom.Equals("Ounces") && (btnLstTo.Equals("Long ton"))))
            {
                return (Convert.ToDouble(txtFromValue) * 0.000028);
            }
            if ((btnLstFrom.Equals("Ounces") && (btnLstTo.Equals("Pounds"))))
            {
                return (Convert.ToDouble(txtFromValue) * 0.0625);
            }
            if ((btnLstFrom.Equals("Ounces") && (btnLstTo.Equals("Ounces"))))
            {
                return Convert.ToDouble(txtFromValue);
            }
            return 0;
        }

        public class MassList : List<MassUnit>
        {
            public MassList()
            {
                Add
                    (
                        new MassUnit
                        {
                            MassUnits = "Grams"
                        });

                Add
                    (
                        new MassUnit
                        {
                            MassUnits = "Kilograms"
                        });

                Add
                    (
                        new MassUnit
                        {
                            MassUnits = "Metric tonnes"
                        });

                Add
                    (
                        new MassUnit
                        {
                            MassUnits = "Short ton"
                        });

                Add
                    (
                        new MassUnit
                        {
                            MassUnits = "Long ton"
                        });

                Add
                    (
                        new MassUnit
                        {
                            MassUnits = "Pounds"
                        });

                Add
                    (
                        new MassUnit
                        {
                            MassUnits = "Ounces"
                        });
            }
        }

        public class MassUnit
        {
            public string MassUnits { get; set; }
        }
    }
}