using System;
using System.Globalization;
using System.Windows.Controls;

namespace CarRentalWPF.Validators
{
    /// <summary>
    /// EmployeeModel - FirstName Property
    /// </summary>
    public class EmployeeFirstNameValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                if (string.IsNullOrWhiteSpace(value.ToString()))
                {
                    return new ValidationResult(false, "Field is required.");
                }
                if (value.ToString().Length < 3 || value.ToString().Length > 30)
                {
                    return new ValidationResult(false, "Name between 3 and 30.");
                }

                return ValidationResult.ValidResult;
            }
            else return new ValidationResult(false, "");
        }
    }

    /// <summary>
    /// EmployeeModel - LastName Property
    /// </summary>
    public class EmployeeLastNameValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                if (string.IsNullOrWhiteSpace(value.ToString()))
                {
                    return new ValidationResult(false, "Field is required.");
                }
                if (value.ToString().Length < 4 || value.ToString().Length > 30)
                {
                    return new ValidationResult(false, "Name between 5 and 30.");
                }

                return ValidationResult.ValidResult;
            }
            else return new ValidationResult(false, "");
        }
    }

    /// <summary>
    /// EmployeeModel - Email Property
    /// </summary>
    public class EmployeeEmailValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value != null)
            {
                if (string.IsNullOrWhiteSpace(value.ToString()))
                {
                    return new ValidationResult(false, "Field is required");
                }

                return ValidationResult.ValidResult;
            }
            else return new ValidationResult(false, "");
        }
    }

    /// <summary>
    /// EmployeeModel - PESEL Property
    /// </summary>
    public class EmployeePESELValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value != null)
            {
                if (string.IsNullOrWhiteSpace(value.ToString()))
                {
                    return new ValidationResult(false, "Field is required");
                }
                if((value.ToString()).Length != 11)
                {
                    return new ValidationResult(false, "PESEL is not valid");
                }

                return ValidationResult.ValidResult;
            }
            else return new ValidationResult(false, "");

        }
    }

    /// <summary>
    /// EmployeeModel - IdCardNumber Property
    /// </summary>
    public class EmployeeIdCardNumberValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                if (string.IsNullOrWhiteSpace(value.ToString()))
                {
                    return new ValidationResult(false, "Field is required");
                }
                if ((value.ToString()).Length != 8)
                {
                    return new ValidationResult(false, "Id Card Number is not valid");
                }

                return ValidationResult.ValidResult;
            }
            else return new ValidationResult(false, "");
        }
    }

    /// <summary>
    /// EmployeeModel - Role Property
    /// </summary>
    public class EmployeeRoleValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            // TODO: Make Role Validator

            return ValidationResult.ValidResult;
        }
    }

    /// <summary>
    /// EmployeeModel - City Property
    /// </summary>
    public class EmployeeCityValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                if (string.IsNullOrWhiteSpace(value.ToString()))
                {
                    return new ValidationResult(false, "Field is required");
                }
                if((value.ToString()).Length > 30 || value.ToString().Length < 3)
                {
                    return new ValidationResult(false, "Field between 3 and 30 characters");
                }

                return ValidationResult.ValidResult;
            }
            else return new ValidationResult(false, "");
        }
    }

    /// <summary>
    /// EmployeeModel - Country Property
    /// </summary>
    public class EmployeeCountryValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                if (string.IsNullOrWhiteSpace(value.ToString()))
                {
                    return new ValidationResult(false, "Field is required");
                }
                if ((value.ToString()).Length > 30 || value.ToString().Length < 3)
                {
                    return new ValidationResult(false, "Field between 3 and 30 characters");
                }

                return ValidationResult.ValidResult;
            }
            else return new ValidationResult(false, "");
        }
    }

    /// <summary>
    /// EmployeeModel - Street Property
    /// </summary>
    public class EmployeeStreetValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                if (string.IsNullOrWhiteSpace(value.ToString()))
                {
                    return new ValidationResult(false, "Field is required");
                }
                if ((value.ToString()).Length > 30 || value.ToString().Length < 3)
                {
                    return new ValidationResult(false, "Field between 3 and 30 characters");
                }

                return ValidationResult.ValidResult;
            }
            else return new ValidationResult(false, "");
        }
    }

    /// <summary>
    /// EmployeeModel - BuildingNo Property
    /// </summary>
    public class EmployeeBuildingNoValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                if (string.IsNullOrWhiteSpace(value.ToString()))
                {
                    return new ValidationResult(false, "Field is required");
                }

                return ValidationResult.ValidResult;
            }
            else return new ValidationResult(false, "");
        }
    }

    /// <summary>
    /// EmployeeModel - FlatNo Property
    /// </summary>
    public class EmployeeFlatNoValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                if (string.IsNullOrWhiteSpace(value.ToString()))
                {
                    return new ValidationResult(false, "Field is required");
                }

                return ValidationResult.ValidResult;
            }
            else return new ValidationResult(false, "");
        }
    }

    /// <summary>
    /// EmployeeModel - PostalCode Property
    /// </summary>
    public class EmployeePostalCodeValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                if (string.IsNullOrWhiteSpace(value.ToString()))
                {
                    return new ValidationResult(false, "Field is required");
                }

                return ValidationResult.ValidResult;
            }
            else return new ValidationResult(false, "");
        }
    }

    /// <summary>
    /// EmployeeModel - PhoneNumber Property
    /// </summary>
    public class EmployeePhoneNumberValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                if (string.IsNullOrWhiteSpace(value.ToString()))
                {
                    return new ValidationResult(false, "Field is required");
                }
                if ((value.ToString()).Length > 12 || value.ToString().Length < 9)
                {
                    return new ValidationResult(false, "Field between 9 and 12 characters");
                }

                return ValidationResult.ValidResult;
            }
            else return new ValidationResult(false, "");
        }
    }
}