using DatingApp.BusinessLayer.Models.User.Request;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.BusinessLayer.Attributes
{
    public class EitherAgeFromOrAgeToRequired : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var userDishRequest = (UserDishRequest)validationContext.ObjectInstance;
            if (userDishRequest.AgeFrom <= 0 && userDishRequest.AgeTo <= 0)
            {
                return new  ValidationResult("Either AgeFrom or AgeTo must be specified.");
            }
            return ValidationResult.Success;
        }
    }
}
