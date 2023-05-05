﻿using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Validations
{
    public class ImgValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var imgext = Path.GetExtension((string)value);

            if (imgext != ".jpg" && imgext != ".png")
                return new ValidationResult("Puoi inserire solo immagini di tipo \".jpg\" e \".png\"");
            return ValidationResult.Success;
        }
    }
}
