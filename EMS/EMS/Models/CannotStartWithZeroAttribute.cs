﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;

public class CannotStartWithZeroAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            string empId = value.ToString();
            if (empId.Length > 0 && empId[0] == '0')
            {
                return new ValidationResult("Employee ID cannot start with zero.");
            }
        }

        return ValidationResult.Success;
    }
}