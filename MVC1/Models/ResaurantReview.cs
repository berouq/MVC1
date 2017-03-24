using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC1.Models
{

public class Ilike : ValidationAttribute
{
    public Ilike()
            : base("I dont like the value of {0}")
    {
    }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
                    var errormsg = FormatErrorMessage(validationContext.DisplayName);

                    if (value != null)
                    {

                            if (value.ToString() == "sirb")
                            {
                                return ValidationResult.Success;
                            }
                            else
                            {
                                return new ValidationResult(errormsg);
                            }

                    }
                    else
                    {
                        return new ValidationResult(errormsg);
                    }

        }




    }





    public class ResaurantReview //: IValidatableObject
    {
        public int Id { get; set; }

        //[Range(1,10)]
        //[Required]
        public int Rating { get; set; }

        //[Required]
        [StringLength(1024)]
        public string Body { get; set; }

        [Display(Name ="User Name")]
        [DisplayFormat(NullDisplayText ="did not enter name")]
        //[Ilike]
        public string ReviewerName { get; set; }
        public int RestaurantId { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Rating < 2 && ReviewerName.ToLower().StartsWith("s"))
        //    {
        //        yield return new ValidationResult("sorry b u cant do this");
        //    }
        //}
    }
}