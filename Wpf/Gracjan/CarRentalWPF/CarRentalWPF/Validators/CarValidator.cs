using System;
using System.Globalization;
using System.Windows.Controls;

namespace CarRentalWPF.Validators
{
    /// <summary>
    /// CarModel - Mark Property
    /// </summary>
    public class CarMarkValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                if (string.IsNullOrWhiteSpace(value.ToString()))
                    return new ValidationResult(false, "Field is required.");

                if (value.ToString().Length < 3 || value.ToString().Length > 30)
                    return new ValidationResult(false, "Mark between 3 and 30.");

                return ValidationResult.ValidResult;
            }
            else return new ValidationResult(false, "");
        }
    }

    /// <summary>
    /// CarModel - Model Property
    /// </summary>
    public class CarModelValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                if (string.IsNullOrWhiteSpace(value.ToString()))
                    return new ValidationResult(false, "Field is required.");
                
                if (value.ToString().Length < 3 || value.ToString().Length > 30)
                    return new ValidationResult(false, "Model between 3 and 30.");
                
                return ValidationResult.ValidResult;
            }
            else return new ValidationResult(false, "");
        }
    }

    /// <summary>
    /// CarModel - Engine Property
    /// </summary>
    public class CarEngineValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                int engine;

                try
                {
                    engine = Convert.ToInt32(value);
                }
                catch(Exception)
                {
                    return new ValidationResult(false, "Engine should be a number");
                }

                if (engine < 100 || engine > 10000)
                    return new ValidationResult(false, "Engine between 100 and 10000");

                return ValidationResult.ValidResult;
            }
            else return new ValidationResult(false, "");
        }
    }

    /// <summary>
    /// CarModel - Power Property
    /// </summary>
    public class CarPowerValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                int power;

                try
                {
                    power = Convert.ToInt32(value);
                }
                catch (Exception)
                {
                    return new ValidationResult(false, "Power should be a number");
                }

                if (power < 5 || power > 1500)
                    return new ValidationResult(false, "Power between 5 and 1500");

                return ValidationResult.ValidResult;
            }
            else return new ValidationResult(false, "");
        }
    }

    /// <summary>
    /// CarModel - Mileage Property
    /// </summary>
    public class CarMileageValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                int mileage;

                try
                {
                    mileage = Convert.ToInt32(value);
                }
                catch (Exception)
                {
                    return new ValidationResult(false, "Mileage should be a number");
                }

                if (mileage < 1)
                    return new ValidationResult(false, "Mileage cannot be less than 1");

                return ValidationResult.ValidResult;
            }
            else return new ValidationResult(false, "");
        }
    }

    /// <summary>
    /// CarModel - Plate Property
    /// </summary>
    public class CarPlateValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                if (string.IsNullOrWhiteSpace(value.ToString()))
                    return new ValidationResult(false, "Field is required.");

                if (value.ToString().Length < 6 || value.ToString().Length > 20)
                    return new ValidationResult(false, "Plate between 5 and 20.");

                return ValidationResult.ValidResult;
            }
            else return new ValidationResult(false, "");
        }
    }

    /// <summary>
    /// CarModel - VIN Property
    /// </summary>
    public class CarVINValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                if (string.IsNullOrWhiteSpace(value.ToString()))
                    return new ValidationResult(false, "Field is required.");

                if (value.ToString().Length != 17)
                    return new ValidationResult(false, "VIN is incorrect");

                return ValidationResult.ValidResult;
            }
            else return new ValidationResult(false, "");
        }
    }
}
