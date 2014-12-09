using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AzureCal.Models
{
    public enum InstanceSize {
        VerySmall, Small,Medium,Large,VeryLarge,A6,A7
    }
    public class AzureServiceModel
    {
        public static double[] InstanceSizePrices
        {
            get
            {
                return new double[] { 0.02, 0.08, 0.16, 0.32, 0.64, 0.90, 1.80 };
            }
        }
        [Key]
        public int Id { get;  private set; }

        [Required(ErrorMessage = "Required field")]
        [Range(2, Int32.MaxValue, ErrorMessage = "At least Two instances need to be created")]
        [DisplayName("Number of Instances")]
        public int NumberInstances { get; set; }

        [Required(ErrorMessage = "Required Filed")]
        [DisplayName("Instance Size")]
        public InstanceSize InstanceSize { get; set; }


        public Double cost
        {
            get
            {
                int size = 0;
               if(InstanceSize.Equals(this.InstanceSize))
               {
                   size = this.InstanceSize.GetHashCode();

               }
               double hourlyPrice = NumberInstances * InstanceSizePrices[size];
               double dailyPrice = hourlyPrice * 24;
               double yearlyPrice;

               if (DateTime.IsLeapYear(DateTime.Now.Year))
               {
                   yearlyPrice = dailyPrice * 366;
               }
               else
               {
                   yearlyPrice = dailyPrice * 365;
               }
               return yearlyPrice;
            }
            set
            {

            }
        }
    }

}